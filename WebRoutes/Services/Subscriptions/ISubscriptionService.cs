using WebRoutes.Dtos;
using WebRoutes.Dtos.ResponseDtos;

namespace WebRoutes.Services.Subscriptions;

public interface ISubscriptionService
{
    Task<IEnumerable<SubscriptionResponseDto>> GetAllSubscriptionsAsync(int userId);
        
    Task<IEnumerable<SubscriptionResponseDto>> GetAllFollowersAsync(int userId);
        
    Task<HttpResponseMessage> CreateSubscriptionAsync(int subscriberId, int followeeId);

    Task<HttpResponseMessage> DeleteSubscriptionAsync(int subscriberId, int followedUserId);
}