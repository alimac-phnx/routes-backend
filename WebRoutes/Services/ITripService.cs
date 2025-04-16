using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Route>> GetAllRoutesAsync();
        
        Task<Models.Route?> GetRouteByIdAsync(int id);
        
        Task CreateRouteAsync(Route route);
        
        Task UpdateRouteAsync(Route route);
        
        Task DeleteRouteAsync(int id);
    }
}