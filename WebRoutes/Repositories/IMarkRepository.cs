using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public interface IMarkRepository : IRepository<Mark>
    {
        Task<IEnumerable<Mark>> GetMarksByUserIdAsync(int userId);
        
        Task<IEnumerable<Mark>> GetMarksByRouteIdAsync(int routeId);
    }
}