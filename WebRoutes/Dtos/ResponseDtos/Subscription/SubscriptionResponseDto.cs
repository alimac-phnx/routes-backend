using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Dtos.ResponseDtos;

public class SubscriptionResponseDto
{
    public required int SubscriberId { get; init; }
        
    public required int FolloweeId { get; init; }
    
    public required UserInfoResponseDto SubscriberInfoResponse { get; init; }
}