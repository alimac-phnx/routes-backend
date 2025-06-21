using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Dtos.ResponseDtos.Route;

public class RouteCardUserResponseDto
{
    public RouteInfoResponseDto RouteInfo { get; set; }
    
    public bool IsDone { get; set; }
    
    public bool IsMine { get; set; }
    
    public UserInfoResponseDto UserInfo { get; set; }
    
    public int UserCount { get; set; }
}