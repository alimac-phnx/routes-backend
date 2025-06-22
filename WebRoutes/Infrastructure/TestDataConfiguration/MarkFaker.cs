using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

internal static class MarkFaker
{
    public static ICollection<Mark> CreateGenerateMany(int count, ICollection<User> users, ICollection<Route> routes)
    {
        return new Faker<Mark>()
            .RuleFor(m => m.Id, f => f.IndexFaker + 1)
            .RuleFor(m => m.UserId, f => f.IndexFaker + 1)
            .RuleFor(m => m.User, f => users.FirstOrDefault(u => u.Id == f.IndexFaker + 1))
            .RuleFor(m => m.RouteId, f => f.IndexFaker + 1)
            .RuleFor(m => m.Route, f => routes.FirstOrDefault(r => r.Id == f.IndexFaker + 1))
            .RuleFor(m => m.MarkType, f => MarkType.Mine)
            .Generate(count);
    }
    public static ICollection<Mark> GenerateMany(int count, ICollection<User> users, ICollection<Route> routes)
    {
        return new Faker<Mark>()
            .RuleFor(m => m.Id, f => f.IndexFaker + 1 + count)
            .RuleFor(m => m.UserId, f => f.IndexFaker + 1)
            .RuleFor(m => m.User, f => users.FirstOrDefault(u => u.Id == f.IndexFaker + 1))
            .RuleFor(m => m.RouteId, f => f.IndexFaker + 1)
            .RuleFor(m => m.Route, f => routes.FirstOrDefault(r => r.Id == f.IndexFaker + 1))
            .RuleFor(m => m.MarkType, f => f.PickRandom(MarkType.Liked, MarkType.Done))
            .Generate(count);
    }
}