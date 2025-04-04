using WebRoutes.Models;

namespace WebRoutes.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int userId);
        
        Task<IEnumerable<Subscription>> GetFollowersAsync(int userId);
        
        Task CreateSubscriptionAsync(Subscription subscription);

        Task DeleteSubscriptionAsync(int userId, int followedUserId);
    }
}
