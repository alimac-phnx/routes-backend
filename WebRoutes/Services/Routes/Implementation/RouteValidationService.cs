using WebRoutes.Services.Users;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes.Implementation;

public class RouteValidationService : IRouteValidationService
{
    private readonly IRouteDataService _routeDataService;
    private readonly IUserDataService _userDataService;

    public RouteValidationService(IRouteDataService routeDataService, IUserDataService userDataService)
    {
        _routeDataService = routeDataService;
        _userDataService = userDataService;
    }
    
    public async Task<bool> IsRouteValid(Route route)
    {
        var user = await _userDataService.GetUserByIdAsync(route.UserId);
        
        return await _routeDataService.GetRouteByIdAsync(route.Id)
               == null
               && user != null
               && route.Places.Count != 0;
    }
}