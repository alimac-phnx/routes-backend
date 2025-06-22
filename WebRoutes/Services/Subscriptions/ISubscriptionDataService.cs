using WebRoutes.Models;

namespace WebRoutes.Services.Subscriptions
{
    public interface ISubscriptionDataService
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int userId);
        
        Task<IEnumerable<Subscription>> GetFollowersAsync(int userId);
        
        Task CreateSubscriptionAsync(int userId, int followeeId);

        Task DeleteSubscriptionAsync(Subscription subscription);
    }
}
