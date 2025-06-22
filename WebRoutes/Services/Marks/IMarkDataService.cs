using WebRoutes.Models;

namespace WebRoutes.Services.Marks
{
    public interface IMarkDataService
    {
        Task<Mark?> GetMarkByIdAsync(int id);
        
        Task<IEnumerable<Mark>> GetMarksByUserAsync(int userId);
        
        Task<IEnumerable<Mark>> GetMarksByRouteAsync(int routeId);
        
        Task CreateMarkAsync(Mark mark);

        Task DeleteMarkAsync(Mark mark);
    }
}
