using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

public static class PointFaker
{
    private static int _id = 1;
    public static ICollection<Point> GenerateMany(int count, ICollection<Coordinate> coordinates)
    {
        return new Faker<Point>()
            .RuleFor(p => p.Id, _ => _id++)
            .RuleFor(p => p.CoordinateId, f => f.PickRandom(coordinates).Id)
            .RuleFor(p => p.LocationId, f => f.IndexFaker + 1)
            .Generate(count);
    }
}