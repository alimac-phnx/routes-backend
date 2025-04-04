using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Dtos;
using WebRoutes.Models;
using WebRoutes.Repositories;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Route>> GetAllRoutesAsync()
        {
            return await _routeRepository.GetRoutesWithDetailsAsync();
        }

        public async Task<Route?> GetRouteByIdAsync(int id)
        {
            return await _routeRepository.GetByIdAsync(id);
        }

        public async Task CreateRouteAsync(Route route)
        {
            await _routeRepository.AddAsync(route);
            await _routeRepository.SaveChangesAsync();
        }

        public async Task UpdateRouteAsync(Route route)
        {
            await _routeRepository.UpdateRouteSimplifiedAsync(route);
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