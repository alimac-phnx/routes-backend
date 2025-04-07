using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class SubscriptionFaker
{
    public static List<Subscription> GenerateMany(int count, List<User> users)
    {
        var subs = new List<Subscription>();
        var faker = new Faker();

        for (int i = 0; i < count; i++)
        {
            var user = faker.PickRandom(users);
            var followed = faker.PickRandom(users.Where(u => u.Id != user.Id));
            
            if (!subs.Any(s => s.UserId == user.Id && s.FollowedUserId == followed.Id))
            {
                subs.Add(new Subscription
                {
                    UserId = user.Id,
                    FollowedUserId = followed.Id
                });
            }
        }

        return subs;
    }
}