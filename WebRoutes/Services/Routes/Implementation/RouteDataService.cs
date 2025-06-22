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

        public async Task<IEnumerable<Route>> GetAllRoutesAsync(int userId, int pageNumber, int pageSize)
        {
            return await _routeRepository.GetRoutesWithDetailsAsync(userId, pageNumber, pageSize);
        }

        public async Task<IEnumerable<Route>> GetAllRoutesForUserAsync(int id, int currentUserId, int pageNumber, int pageSize)
        {
            var routes = await _routeRepository.GetUserMarkedRoutesAsync(id, currentUserId, pageNumber, pageSize);
            
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