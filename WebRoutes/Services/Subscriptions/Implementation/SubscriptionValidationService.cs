using WebRoutes.Models;

namespace WebRoutes.Services.Subscriptions.Implementation;

public class SubscriptionValidationService : ISubscriptionValidationService
{
    private readonly ISubscriptionDataService _subscriptionDataService;

    public SubscriptionValidationService(ISubscriptionDataService subscriptionDataService)
    {
        _subscriptionDataService = subscriptionDataService;
    }
    
    public async Task<bool> IsValidSubscription(int subscriberId, int followeeId)
    {
        return await GetExistingSubscription(subscriberId, followeeId) == null && subscriberId != followeeId;
    }
    
    public async Task<Subscription?> GetExistingSubscription(int subscriberId, int followeeId)
    {
        var existingUserSubscriptions = await _subscriptionDataService.GetSubscriptionsAsync(subscriberId);

        return existingUserSubscriptions.SingleOrDefault(s => s.FolloweeId == followeeId);
    }
}