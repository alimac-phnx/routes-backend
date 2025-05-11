using WebRoutes.Models;

namespace WebRoutes.Services.Subscriptions;

public interface ISubscriptionValidationService
{
    Task<bool> IsValidSubscription(int subscriberId, int followeeId);

    Task<Subscription?> GetExistingSubscription(int subscriberId, int followeeId);
}