using Microsoft.EntityFrameworkCore;
using WebRoutes.Dtos;
using WebRoutes.Infrastructure;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Route>> GetRoutesWithDetailsAsync()
        {
            return await _context.Routes
                .Include(r => r.User)
                .Include(r => r.Places)
                .Include(r => r.AdditionalPlaces)
                .ToListAsync();
        }

        public async Task UpdateRouteSimplifiedAsync(Route route)
        {
            var existingRoute = await _context.Routes
                .Include(r => r.Places)
                .FirstOrDefaultAsync(r => r.Id == route.Id);

            if (existingRoute == null)
            {
                throw new Exception("Маршрут не найден.");
            }

            _context.Entry(existingRoute).CurrentValues.SetValues(route);

            var newPlaceIds = route.Places.Select(p => p.Id).ToList();
            var newAddPlaceIds = route.AdditionalPlaces.Select(a => a.Id).ToList();

            var placesToRemove = existingRoute.Places
                .Where(p => !newPlaceIds.Contains(p.Id))
                .ToArray();
            var addplacesToRemove = existingRoute.AdditionalPlaces
                .Where(p => !newAddPlaceIds.Contains(p.Id))
                .ToList();

            foreach (var place in placesToRemove)
            {
                existingRoute.Places.Remove(place);
            }

            addplacesToRemove.ForEach(a => existingRoute.AdditionalPlaces.Remove(a));

            foreach (var placeId in newPlaceIds)
            {
                if (!existingRoute.Places.Any(p => p.Id == placeId))
                {
                    var place = await _context.Places.FindAsync(placeId);
                    if (place == null)
                    {
                        throw new Exception($"Место с ID {placeId} не найдено.");
                    }
                    existingRoute.Places.Add(place);
                }
            }

            foreach (var addplaceId in newAddPlaceIds)
            {
                if (!existingRoute.Places.Any(p => p.Id == addplaceId))
                {
                    var place = await _context.Places.FindAsync(addplaceId);
                    if (place == null)
                    {
                        throw new Exception($"Место с ID {addplaceId} не найдено.");
                    }
                    existingRoute.Places.Add(place);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}