using WebRoutes.Models;

namespace WebRoutes.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetAllRoutesAsync();
        
        Task<Models.Trip?> GetRouteByIdAsync(int id);
        
        Task CreateRouteAsync(Trip trip);
        
        Task UpdateRouteAsync(Trip trip);
        
        Task DeleteRouteAsync(int id);
    }
}