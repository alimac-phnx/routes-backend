using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.Subscriptions.Implementation
{
    internal class SubscriptionDataService : ISubscriptionDataService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionDataService(ISubscriptionRepository subscriptionRepository)
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

        public async Task CreateSubscriptionAsync(int subscriberId, int followeeId)
        {
            var subscription = new Subscription
            {
                SubscriberId = subscriberId,
                FolloweeId = followeeId,
            };
            
            await _subscriptionRepository.AddSubscriptionAsync(subscription);
        }

        public async Task DeleteSubscriptionAsync(Subscription subscription)
        {
            await _subscriptionRepository.RemoveSubscriptionAsync(subscription);
        }
    }
}