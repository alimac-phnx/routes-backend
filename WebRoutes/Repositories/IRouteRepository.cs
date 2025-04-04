using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    public interface IRouteRepository : IRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithDetailsAsync();

        Task UpdateRouteSimplifiedAsync(Route route);
    }
}