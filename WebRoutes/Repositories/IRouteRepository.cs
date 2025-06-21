using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    internal interface IRouteRepository : IRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithDetailsAsync(int userId);

        Task<IEnumerable<Route>> GetUserFavoriteRoutesAsync(int id, int currentUserId);

        Task<IEnumerable<Route>> GetUserDoneRoutesAsync(int id, int currentUserId);

        Task<IEnumerable<Route>> GetUserCreatedRoutesAsync(int id, int currentUserId);
        
        Task<Route?> GetRouteByIdAsync(int id);

        Task<Route?> GetRouteWithDetailsByIdAsync(int id, int userId);

        Task UpdateRouteSimplifiedAsync(Route route);
    }
}