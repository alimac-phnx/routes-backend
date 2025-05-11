using Bogus;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class PointFaker
{
    private static int _id = 1;
    public static ICollection<Point> GenerateMany(int count)
    {
        return new Faker<Point>()
            .RuleFor(p => p.Id, _ => _id++)
            .RuleFor(p => p.Latitude, f => f.Address.Latitude())
            .RuleFor(p => p.Longitude, f => f.Address.Longitude())
            .RuleFor(p => p.LocationId, f => f.IndexFaker + 1)
            .Generate(count);
    }
}