using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IBasePlaceRepository<Place> _placeRepository;

        public PlaceService(IBasePlaceRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<IEnumerable<Place>> GetAllPlacesAsync()
        {
            return await _placeRepository.GetAllAsync();
        }

        public async Task<Place?> GetPlaceByIdAsync(int id)
        {
            return await _placeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Place>> GetPlacesOrderedByVisitAsync()
        {
            var places = await _placeRepository.GetAllAsync();
            return places.OrderBy(p => p.OrderOfVisit);
        }

        public async Task CreatePlaceAsync(Place place)
        {
            await _placeRepository.AddAsync(place);
            await _placeRepository.SaveChangesAsync();
        }

        public async Task UpdatePlaceAsync(Place place)
        {
            _placeRepository.Update(place);
            await _placeRepository.SaveChangesAsync();
        }

        public async Task DeletePlaceAsync(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);
            if (place != null)
            {
                _placeRepository.Delete(place);
                await _placeRepository.SaveChangesAsync();
            }
        }
    }
}