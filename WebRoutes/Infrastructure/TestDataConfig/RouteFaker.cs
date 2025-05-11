using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfig;

internal static class RouteFaker
{
    private static int _id = 1;

    public static ICollection<Route> GenerateMany(int count, ICollection<User> users)
    {
        return new Faker<Route>()
            .RuleFor(r => r.Id, f => _id++)
            .RuleFor(r => r.UserId, f => f.PickRandom(users).Id)
            .RuleFor(r => r.Name, f => f.Lorem.Sentence(2))
            .RuleFor(r => r.Type, f => f.PickRandom<RouteType>())
            .RuleFor(r => r.Theme, f => f.Lorem.Word())
            .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
            .RuleFor(r => r.Length, f => f.Random.Float(1, 20))
            .RuleFor(r => r.Duration, f => TimeSpan.FromHours(f.Random.Double(0.5, 6)))
            .RuleFor(u => u.ImagesUrls, f => f.Make(f.Random.Int(1, 7), () => f.Image.PicsumUrl()).ToList())
            .RuleFor(r => r.Difficulty, f => f.PickRandom<RouteDifficulty>())
            .RuleFor(r => r.Rating, f => f.Random.Float(1, 5))
            .RuleFor(r => r.DateUploaded, f => f.Date.Past().ToUniversalTime())
            .Generate(count);
    }
}