using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Services.AdditionalPlaces
{
    public interface IAdditionalPlaceDataService
    {
        //Task<IEnumerable<AdditionalPlace>> GetAllAdditionalPlacesAsync();
        
        //Task<AdditionalPlace?> GetAdditionalPlaceByIdAsync(int id);
        
        Task CreateAdditionalPlaceAsync(AdditionalPlace additionalPlace);

        Task UpdateAdditionalPlaceAsync(AdditionalPlace additionalPlace);
        
        //Task<IEnumerable<AdditionalPlace>> GetAdditionalPlacesByTypeAsync(AdditionalPlaceType type);
        
        Task DeleteAdditionalPlaceAsync(int id);
    }
}