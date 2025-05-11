using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    internal interface ITripRepository : IRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithDetailsAsync();
        Task<Route?> GetRouteWithDetailsByIdAsync(int id);

        Task UpdateRouteSimplifiedAsync(Route route);
    }
}