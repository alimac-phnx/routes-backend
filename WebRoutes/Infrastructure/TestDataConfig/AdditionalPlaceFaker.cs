using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfig;

internal static class AdditionalPlaceFaker
{
    public static ICollection<AdditionalPlace> GenerateMany(int count, ICollection<Point> points)
    {
        return new Faker<AdditionalPlace>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.RouteId, f => f.Random.Int(1, count))
            .RuleFor(p => p.Name, f => f.Company.CompanyName())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.PointId, f => points.Single(s => s.Id == f.IndexFaker + 1 + count).Id)
            .RuleFor(p => p.Type, f => f.PickRandom<AdditionalPlaceType>())
            .Generate(count);
    }
}