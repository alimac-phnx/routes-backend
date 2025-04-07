using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class MarkFaker
{
    private static int _id = 1;

    public static List<Mark> GenerateMany(int count, List<User> users, List<Trip> routes)
    {
        return new Faker<Mark>()
            .RuleFor(m => m.Id, _ => _id++)
            .RuleFor(m => m.UserId, f => f.PickRandom(users).Id)
            .RuleFor(m => m.TripId, f => f.PickRandom(routes).Id)
            .RuleFor(m => m.MarkType, f => f.PickRandom<MarkType>())
            .Generate(count);
    }
}