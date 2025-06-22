using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

internal static class ReviewFaker
{
    private static int _id = 1;

    public static ICollection<Review> GenerateMany(int count, ICollection<User> users)
    {
        return new Faker<Review>()
            .RuleFor(r => r.Id, _ => _id++)
            .RuleFor(r => r.UserId, f => f.PickRandom(users).Id)
            .RuleFor(p => p.RouteId, f => f.Random.Int(1, count))
            .RuleFor(r => r.Text, f => f.Lorem.Paragraph())
            .RuleFor(r => r.Grade, f => f.Random.Int(1, 5))
            .Generate(count);
    }
}