using WebRoutes.Models;
using WebRoutes.Services.Routes;
using WebRoutes.Services.Users;

namespace WebRoutes.Services.Marks.Implementation;

public class MarkValidationService : IMarkValidationService
{
    private readonly IMarkDataService _markDataService;
    private readonly IUserDataService _userDataService;
    private readonly IRouteDataService _routeDataService;

    public MarkValidationService(
        IMarkDataService markDataService, IUserDataService userDataService, IRouteDataService routeDataService)
    {
        _markDataService = markDataService;
        _userDataService = userDataService;
        _routeDataService = routeDataService;
    }

    public async Task<bool> IsMarkValid(Mark mark)
    {
        var user = await _userDataService.GetUserByIdAsync(mark.UserId);
        var route = await _routeDataService.GetRouteByIdAsync(mark.RouteId);
        var userMarks = await _markDataService.GetMarksByUserAsync(mark.UserId);
        
        return !userMarks.Contains(mark) && user != null && route != null && Enum.IsDefined(mark.MarkType); ;
    }
}