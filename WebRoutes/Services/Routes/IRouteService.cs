using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes;

public interface IRouteService
{
    Task<IEnumerable<RouteCardResponseDto>> GetAllRoutesAsync(int userId, int pageNumber, int pageSize);

    Task<IEnumerable<RouteCardUserResponseDto>> GetAllRoutesForUserAsync(int id, int currentUserId, int pageNumber, int pageSize);
    
    Task<RoutePostResponseDto> GetRouteByIdAsync(int id, int userId);
        
    Task<HttpResponseMessage> CreateRouteByRequestAsync(RouteCreateRequestDto routeCreateRequest);
        
    Task<HttpResponseMessage> UpdateRouteByRequestAsync(int id, RouteUpdateRequestDto routeUpdateRequest);
        
    Task<HttpResponseMessage> DeleteRouteAsync(int id);
}