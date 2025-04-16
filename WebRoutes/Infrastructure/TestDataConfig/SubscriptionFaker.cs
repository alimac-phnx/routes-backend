using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class SubscriptionFaker
{
    public static ICollection<Subscription> GenerateMany(int count, ICollection<User> users)
    {
        var subscriptions = new HashSet<(int SubscriberId, int FolloweeId)>();
        
        return new Faker<Subscription>()
            .CustomInstantiator(f =>
            {
                int subscriberId, followeeId;
                
                do
                {
                    subscriberId = f.PickRandom(users).Id;
                    followeeId = f.PickRandom(users).Id;
                } while (subscriberId == followeeId || subscriptions.Contains((subscriberId, followeeId)));

                subscriptions.Add((subscriberId, followeeId));

                return new Subscription
                {
                    SubscriberId = subscriberId,
                    FolloweeId = followeeId,
                };
            })
            .Generate(count);
    }
}