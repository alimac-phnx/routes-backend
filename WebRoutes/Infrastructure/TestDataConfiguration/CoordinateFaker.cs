using Bogus;
using Coordinate = WebRoutes.Models.Coordinate;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

public class CoordinateFaker
{
    private static int _id = 1;
    public static ICollection<Coordinate> GenerateMany(int count)
    {
        return new Faker<Coordinate>()
            .RuleFor(c => c.Id, _ => _id++)
            .RuleFor(c => c.Latitude, f => (float)f.Address.Latitude())
            .RuleFor(c => c.Longitude, f => (float)f.Address.Longitude())
            .Generate(count);
    }
}