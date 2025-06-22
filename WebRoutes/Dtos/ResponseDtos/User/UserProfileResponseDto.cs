namespace WebRoutes.Dtos.ResponseDtos.User;

public class UserProfileResponseDto
{
    public required UserInfoResponseDto UserInfo { get; init; }
    
    public int Distance { get; init; }
    
    public required int SubscriptionsNumber { get; init; }
    
    public required int FollowersNumber { get; init; }
}