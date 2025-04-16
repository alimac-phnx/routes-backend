using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.implementation
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int userId)
        {
            return await _subscriptionRepository.GetSubscriptionsByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Subscription>> GetFollowersAsync(int userId)
        {
            return await _subscriptionRepository.GetFollowersByUserIdAsync(userId);
        }

        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            var existingSubscription = await _subscriptionRepository
                .GetSubscriptionsByUserIdAsync(subscription.SubscriberId);
            if (existingSubscription.SingleOrDefault(s => s.FolloweeId == subscription.FolloweeId) != null || subscription.SubscriberId == subscription.FolloweeId)
            {
                return;
            }
            
            await _subscriptionRepository.AddSubscriptionAsync(subscription);
            await _subscriptionRepository.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionAsync(int userId, int followedUserId)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionsByUserIdAsync(userId);
            var subToDelete = subscription.FirstOrDefault(s => s.FolloweeId == followedUserId);
            if (subToDelete != null)
            {
                _subscriptionRepository.Delete(subToDelete);
                await _subscriptionRepository.SaveChangesAsync();
            }
        }
    }
}