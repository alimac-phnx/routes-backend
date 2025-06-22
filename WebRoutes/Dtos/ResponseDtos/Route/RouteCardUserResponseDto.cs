using WebRoutes.Dtos.ResponseDtos.Common;
using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Dtos.ResponseDtos.Route;

public class RouteCardUserResponseDto
{
    public RouteInfoResponseDto RouteInfo { get; set; }
    
    public List<UserMark> UserMarks { get; set; }
    
    public UserInfoResponseDto UserInfo { get; set; }
    
    public int UserCount { get; set; }
}