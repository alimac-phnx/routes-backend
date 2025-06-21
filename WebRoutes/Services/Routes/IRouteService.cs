using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes;

public interface IRouteService
{
    Task<IEnumerable<RouteCardResponseDto>> GetAllRoutesAsync(int userId);

    Task<IEnumerable<RouteCardUserResponseDto>> GetAllRoutesForUserAsync(int id, int currentUserId);
    
    Task<RoutePostResponseDto> GetRouteByIdAsync(int id, int userId);
        
    Task<HttpResponseMessage> CreateRouteByRequestAsync(RouteCreateRequestDto routeCreateRequest);
        
    Task<HttpResponseMessage> UpdateRouteByRequestAsync(int id, RouteUpdateRequestDto routeUpdateRequest);
        
    Task DeleteRouteAsync(int id);
}