using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Dtos.ResponseDtos.User;

public class UserProfileResponseDto
{
    public required UserInfoResponseDto UserInfo { get; init; }
    
    public int Distance { get; init; }
    
    public required ICollection<RouteCardResponseDto> Routes { get; init; }
    
    public required int SubscriptionsNumber { get; init; }
    
    public required int FollowersNumber { get; init; }

    public required ICollection<Subscription> Subscriptions { get; init; }
}