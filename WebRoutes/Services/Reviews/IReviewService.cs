using WebRoutes.Dtos.RequestDtos.Reviews;
using WebRoutes.Dtos.ResponseDtos.Reviews;

namespace WebRoutes.Services.Reviews;

public interface IReviewService
{
    Task<IEnumerable<ReviewResponseDto>> GetReviewsByRouteAsync(int routeId);
    
    Task<HttpResponseMessage> CreateReviewAsync(ReviewCreateRequestDto reviewCreateRequest);

    Task DeleteReviewAsync(int id);
}