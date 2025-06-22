using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Repositories
{
    internal interface IRouteRepository : IRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithDetailsAsync(int userId, int pageNumber, int pageSize);

        Task<IEnumerable<Route>> GetUserMarkedRoutesAsync(int id, int currentUserId, int pageNumber, int pageSize);

        Task<IEnumerable<Route>> GetUserDoneRoutesAsync(int id, int currentUserId, int pageNumber, int pageSize);

        Task<IEnumerable<Route>> GetUserCreatedRoutesAsync(int id, int currentUserId, int pageNumber, int pageSize);
        
        Task<Route?> GetRouteByIdAsync(int id);

        Task<Route?> GetRouteWithDetailsByIdAsync(int id, int userId);

        Task UpdateRouteSimplifiedAsync(Route route);
    }
}