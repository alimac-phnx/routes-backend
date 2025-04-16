using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class MarkFaker
{
    private static int _id = 1;

    public static ICollection<Mark> GenerateMany(int count, ICollection<User> users, ICollection<Route> routes)
    {
        return new Faker<Mark>()
            .RuleFor(m => m.Id, f => f.IndexFaker + 1)
            .RuleFor(m => m.UserId, f => f.IndexFaker + 1)
            .RuleFor(m => m.RouteId, f => f.IndexFaker + 1)
            .RuleFor(m => m.MarkType, f => f.PickRandom<MarkType>())
            .Generate(count);
    }
}