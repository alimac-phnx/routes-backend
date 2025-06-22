using WebRoutes.Models;

namespace WebRoutes.Services.Reviews;

public interface IReviewDataService
{
    Task<Review?> GetReviewByIdAsync(int id);

    Task<IEnumerable<Review>> GetReviewsByRouteAsync(int routeId, int pageNumber, int pageSize);

    Task CreateReviewAsync(Review review);

    Task DeleteReviewAsync(Review review);
}