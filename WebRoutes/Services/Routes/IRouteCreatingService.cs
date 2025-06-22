using Route = WebRoutes.Models.Route;
using WebRoutes.Dtos.RequestDtos.Routes;

namespace WebRoutes.Services.Routes;

public interface IRouteCreatingService
{
    Task<Route> CreateRouteDataAsync(RouteCreateRequestDto routeCreateRequest, Route route);
}