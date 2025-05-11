using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes;

public interface IRouteService
{
    Task<IEnumerable<RouteCardResponseDto>> GetAllRoutesAsync();
        
    Task<RoutePostResponseDto> GetRouteByIdAsync(int id);
        
    Task<HttpResponseMessage> CreateRouteAsync(Route route);
        
    Task UpdateRouteAsync(Route route);
        
    Task DeleteRouteAsync(int id);
}