using WebRoutes.Models;

namespace WebRoutes.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<IEnumerable<Review>> GetReviewsByRouteIdAsync(int routeId, int pageNumber, int pageSize);
}