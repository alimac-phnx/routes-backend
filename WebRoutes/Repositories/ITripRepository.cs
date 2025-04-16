using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    public interface ITripRepository : IRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithDetailsAsync();

        Task UpdateRouteSimplifiedAsync(Route route);
    }
}