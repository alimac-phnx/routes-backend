using WebRoutes.Models;

namespace WebRoutes.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetAllPlacesAsync();
        
        Task<Place?> GetPlaceByIdAsync(int id);
        
        Task<IEnumerable<Place>> GetPlacesOrderedByVisitAsync();
        
        Task CreatePlaceAsync(Place place);
        
        Task UpdatePlaceAsync(Place place);
        
        Task DeletePlaceAsync(int id);
    }
}