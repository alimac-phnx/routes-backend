using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes;

public interface IRouteService
{
    Task<IEnumerable<RouteCardResponseDto>> GetAllRoutesAsync();
        
    Task<RoutePostResponseDto> GetRouteByIdAsync(int id);
        
    Task<HttpResponseMessage> CreateRouteByRequestAsync(RouteCreateRequestDto routeCreateRequest);
        
    Task<HttpResponseMessage> UpdateRouteByRequestAsync(int id, RouteUpdateRequestDto routeUpdateRequest);
        
    Task DeleteRouteAsync(int id);
}