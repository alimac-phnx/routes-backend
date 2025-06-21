using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes
{
    public interface IRouteDataService
    {
        Task<IEnumerable<Route>> GetAllRoutesAsync(int userId);

        Task<IEnumerable<Route>> GetAllRoutesForUserAsync(int userId);
        
        Task<Route?> GetRouteByIdAsync(int id);
        
        Task<Route?> GetRouteWithDetailsByIdAsync(int id, int userId);
        
        Task CreateRouteAsync(Route route);
        
        Task UpdateRouteAsync(Route route);
        
        Task DeleteRouteAsync(int id);
    }
}