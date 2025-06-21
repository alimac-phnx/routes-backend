using WebRoutes.Repositories;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes.Implementation
{
    internal class RouteDataService : IRouteDataService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteDataService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<Route>> GetAllRoutesAsync(int userId)
        {
            return await _routeRepository.GetRoutesWithDetailsAsync(userId);
        }

        public async Task<IEnumerable<Route>> GetAllRoutesForUserAsync(int id, int currentUserId)
        {
            var routes = new List<Route>();
            var favoriteRoutes = await _routeRepository.GetUserFavoriteRoutesAsync(id, currentUserId);
            routes.AddRange(favoriteRoutes);
            var doneRoutes = await _routeRepository.GetUserDoneRoutesAsync(id, currentUserId);
            routes.AddRange(doneRoutes);
            var createdRoutes = await _routeRepository.GetUserCreatedRoutesAsync(id, currentUserId);
            routes.AddRange(createdRoutes);
            
            return routes;
        }

        public async Task<Route?> GetRouteByIdAsync(int id)
        {
            return await _routeRepository.GetRouteByIdAsync(id);
        }

        public async Task<Route?> GetRouteWithDetailsByIdAsync(int id, int userId)
        {
            return await _routeRepository.GetRouteWithDetailsByIdAsync(id, userId);
        }

        public async Task CreateRouteAsync(Route route)
        {
            await _routeRepository.AddAsync(route);
            await _routeRepository.SaveChangesAsync();
        }

        public async Task UpdateRouteAsync(Route route)
        {
            _routeRepository.Update(route);
            await _routeRepository.SaveChangesAsync();
        }

        public async Task DeleteRouteAsync(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);
            if (route != null)
            {
                _routeRepository.Delete(route);
                await _routeRepository.SaveChangesAsync();
            }
        }
    }
}