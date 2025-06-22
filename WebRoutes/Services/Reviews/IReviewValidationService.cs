using WebRoutes.Models;

namespace WebRoutes.Services.Reviews;

public interface IReviewValidationService
{
    Task<bool> IsReviewValid(Review review);
}