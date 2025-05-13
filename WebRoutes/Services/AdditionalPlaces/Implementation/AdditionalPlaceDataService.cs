using WebRoutes.Enums;
using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.AdditionalPlaces.Implementation
{
    internal class AdditionalPlaceDataService : IAdditionalPlaceDataService
    {
        private readonly ILocationRepository<AdditionalPlace> _additionalPlaceRepository;

        public AdditionalPlaceDataService(ILocationRepository<AdditionalPlace> additionalPlaceRepository)
        {
            _additionalPlaceRepository = additionalPlaceRepository;
        }

        /*public async Task<IEnumerable<AdditionalPlace>> GetAllAdditionalPlacesAsync()
        {
            return await _additionalPlaceRepository.GetAllAsync();
        }*/

        /*public async Task<AdditionalPlace?> GetAdditionalPlaceByIdAsync(int id)
        {
            return await _additionalPlaceRepository.GetByIdAsync(id);
        }*/

        /*public async Task<IEnumerable<AdditionalPlace>> GetAdditionalPlacesByTypeAsync(AdditionalPlaceType type)
        {
            var additionalPlaces = await _additionalPlaceRepository.GetAllAsync();
            return additionalPlaces.Where(ap => ap.Type == type);
        }*/

        public async Task CreateAdditionalPlaceAsync(AdditionalPlace additionalPlace)
        {
            await _additionalPlaceRepository.AddAsync(additionalPlace);
            await _additionalPlaceRepository.SaveChangesAsync();
        }

        public async Task UpdateAdditionalPlaceAsync(AdditionalPlace additionalPlace)
        {
            //_additionalPlaceRepository.Update(additionalPlace);
            //await _additionalPlaceRepository.SaveChangesAsync();
        }

        public async Task DeleteAdditionalPlaceAsync(int id)
        {
            //var additionalPlace = await _additionalPlaceRepository.GetByIdAsync(id);
            //if (additionalPlace != null)
            //{
            //    _additionalPlaceRepository.Delete(additionalPlace);
            //    await _additionalPlaceRepository.SaveChangesAsync();
            //}
        }
    }
}