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

        public async Task<IEnumerable<Route>> GetAllRoutesAsync()
        {
            return await _routeRepository.GetRoutesWithDetailsAsync();
        }

        public async Task<Route?> GetRouteByIdAsync(int id)
        {
            return await _routeRepository.GetRouteWithDetailsByIdAsync(id);
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