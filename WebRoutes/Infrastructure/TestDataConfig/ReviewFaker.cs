using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class ReviewFaker
{
    private static int _id = 1;

    public static List<Review> GenerateMany(int count, List<User> users, List<Trip> routes)
    {
        return new Faker<Review>()
            .RuleFor(r => r.Id, _ => _id++)
            .RuleFor(r => r.UserId, f => f.PickRandom(users).Id)
            .RuleFor(r => r.TripId, f => f.PickRandom(routes).Id)
            .RuleFor(r => r.Header, f => f.Lorem.Sentence())
            .RuleFor(r => r.Text, f => f.Lorem.Paragraph())
            .RuleFor(r => r.Grade, f => f.Random.Int(1, 5))
            .RuleFor(r => r.DateUploaded, f => f.Date.Recent().ToUniversalTime())
            .Generate(count);
    }
}