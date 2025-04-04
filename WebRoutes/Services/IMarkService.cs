using WebRoutes.Models;

namespace WebRoutes.Services
{
    public interface IMarkService
    {
        Task<IEnumerable<Mark>> GetMarksByUserAsync(int userId);
        
        Task<IEnumerable<Mark>> GetMarksByRouteAsync(int routeId);
        
        Task CreateMarkAsync(Mark mark);
        
        Task DeleteMarkAsync(int userId, int routeId);
    }
}
