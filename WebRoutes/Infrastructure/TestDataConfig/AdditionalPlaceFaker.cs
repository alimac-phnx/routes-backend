using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class AdditionalPlaceFaker
{

    public static ICollection<AdditionalPlace> GenerateMany(int count, ICollection<Point> points)
    {
        return new Faker<AdditionalPlace>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Company.CompanyName())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.PointId, f => points.Single(s => s.LocationId == f.IndexFaker + 1).Id)
            .RuleFor(p => p.Type, f => f.PickRandom<AdditionalPlaceType>())
            .Generate(count);
    }
}