using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes
{
    internal interface IRouteDataService
    {
        Task<IEnumerable<Route>> GetAllRoutesAsync();
        
        Task<Route?> GetRouteByIdAsync(int id);
        
        Task CreateRouteAsync(Route route);
        
        Task UpdateRouteAsync(Route route);
        
        Task DeleteRouteAsync(int id);
    }
}