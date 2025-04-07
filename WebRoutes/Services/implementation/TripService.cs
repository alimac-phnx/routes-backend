using AutoMapper;
using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.implementation
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Trip>> GetAllRoutesAsync()
        {
            return await _tripRepository.GetRoutesWithDetailsAsync();
        }

        public async Task<Trip?> GetRouteByIdAsync(int id)
        {
            return await _tripRepository.GetByIdAsync(id);
        }

        public async Task CreateRouteAsync(Trip trip)
        {
            await _tripRepository.AddAsync(trip);
            await _tripRepository.SaveChangesAsync();
        }

        public async Task UpdateRouteAsync(Trip trip)
        {
            await _tripRepository.UpdateRouteSimplifiedAsync(trip);
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