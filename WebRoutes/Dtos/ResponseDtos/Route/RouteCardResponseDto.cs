using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Dtos.ResponseDtos.Route;

public class RouteCardResponseDto
{
    public RouteInfoResponseDto RouteInfo { get; set; }
    
    public UserInfoResponseDto UserInfo { get; set; }
    
    public int UserCount { get; set; }
}