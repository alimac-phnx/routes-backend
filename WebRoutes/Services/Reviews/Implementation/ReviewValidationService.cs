using WebRoutes.Models;
using WebRoutes.Services.Marks;
using WebRoutes.Services.Routes;
using WebRoutes.Services.Users;

namespace WebRoutes.Services.Reviews.Implementation;

public class ReviewValidationService : IReviewValidationService
{
    private readonly IReviewDataService _reviewDataService;
    private readonly IUserDataService _userDataService;
    private readonly IRouteDataService _routeDataService;

    public ReviewValidationService(
        IReviewDataService reviewDataService, IUserDataService userDataService, IRouteDataService routeDataService)
    {
        _reviewDataService = reviewDataService;
        _userDataService = userDataService;
        _routeDataService = routeDataService;
    }

    public async Task<bool> IsReviewValid(Review review)
    {
        var user = await _userDataService.GetUserByIdAsync(review.UserId);
        var route = await _routeDataService.GetRouteByIdAsync(review.RouteId);

        return user != null && route != null && review.Grade >= 0 && review.Grade <= 5;
    }
}