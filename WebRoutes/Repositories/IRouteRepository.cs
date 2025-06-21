using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    internal interface IRouteRepository : IRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithDetailsAsync(int userId);

        Task<IEnumerable<Route>> GetRoutesForUserWithDetailsAsync(int userId);
        
        Task<Route?> GetRouteByIdAsync(int id);

        Task<Route?> GetRouteWithDetailsByIdAsync(int id, int userId);

        Task UpdateRouteSimplifiedAsync(Route route);
    }
}