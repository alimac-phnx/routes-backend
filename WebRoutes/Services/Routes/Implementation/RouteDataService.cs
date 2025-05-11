using AutoMapper;
using WebRoutes.Repositories;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes.Implementation
{
    internal class RouteDataService : IRouteDataService
    {
        private readonly ITripRepository _tripRepository;

        private readonly IMapper _mapper;

        public RouteDataService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Route>> GetAllRoutesAsync()
        {
            return await _tripRepository.GetRoutesWithDetailsAsync();
        }

        public async Task<Route?> GetRouteByIdAsync(int id)
        {
            return await _tripRepository.GetRouteWithDetailsByIdAsync(id);
        }

        public async Task CreateRouteAsync(Route route)
        {
            await _tripRepository.AddAsync(route);
            await _tripRepository.SaveChangesAsync();
        }

        public async Task UpdateRouteAsync(Route route)
        {
            await _tripRepository.UpdateRouteSimplifiedAsync(route);
            await _tripRepository.SaveChangesAsync();
        }

        public async Task DeleteRouteAsync(int id)
        {
            var route = await _tripRepository.GetByIdAsync(id);
            if (route != null)
            {
                _tripRepository.Delete(route);
                await _tripRepository.SaveChangesAsync();
            }
        }
    }
}