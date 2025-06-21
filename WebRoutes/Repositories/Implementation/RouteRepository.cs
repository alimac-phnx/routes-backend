using Microsoft.EntityFrameworkCore;
using WebRoutes.Enums;
using WebRoutes.Infrastructure;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories.implementation
{
    internal class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Route>> GetRoutesWithDetailsAsync(int userId)
        {
            return await _context.Routes
                .Include(r => r.User)
                .Include(r => r.Marks!.Where(m => m.UserId == userId))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Route>> GetUserFavoriteRoutesAsync(int id, int currentUserId)
        {
            return await _context.Routes
                .Where(r => r.Marks!.Any(m => m.UserId == id && m.MarkType == MarkType.Liked))
                .Include(r => r.Marks!.Where(m => m.UserId == currentUserId))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Route>> GetUserDoneRoutesAsync(int id, int currentUserId)
        {
            return await _context.Routes
                .Where(r => r.Marks!.Any(m => m.UserId == id && m.MarkType == MarkType.Done))
                .Include(r => r.Marks!.Where(m => m.UserId == currentUserId))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Route>> GetUserCreatedRoutesAsync(int id, int currentUserId)
        {
            return await _context.Routes
                .Where(r => r.Marks!.Any(m => m.UserId == id && m.MarkType == MarkType.Mine))
                .Include(r => r.Marks!.Where(m => m.UserId == currentUserId))
                .ToListAsync();
        }
        
        public async Task<Route?> GetRouteByIdAsync(int id)
        {
            return await _context.Routes
                .Include(r => r.User)
                .Include(r => r.Places)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        
        public async Task<Route?> GetRouteWithDetailsByIdAsync(int id, int userId)
        {
            return await _context.Routes
                .Include(r => r.User)
                .Include(r => r.Places)
                .ThenInclude(p => p.Point)
                .Include(r => r.AdditionalPlaces)!
                .ThenInclude(ap => ap.Point)
                .ThenInclude(p => p.Coordinate)
                .Include(r => r.RoutePath)
                .Include(r => r.Marks!.Where(m => m.UserId == userId))
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateRouteSimplifiedAsync(Route route)
        {
            var existingRoute = await _context.Routes
                .Include(r => r.Places)
                .Include(r => route.AdditionalPlaces)
                .Include(r => r.Marks)
                .FirstOrDefaultAsync(r => r.Id == route.Id);

            if (existingRoute == null)
            {
                throw new Exception("Route not found");
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