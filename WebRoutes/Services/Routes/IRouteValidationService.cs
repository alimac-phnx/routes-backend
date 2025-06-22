using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes;

public interface IRouteValidationService
{
    Task<bool> IsRouteValid(Route route);
}