using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class AdditionalPlaceFaker
{
    private static int _id = 1;

    public static List<AdditionalPlace> GenerateMany(int count, List<Trip> routes)
    {
        return new Faker<AdditionalPlace>()
            .RuleFor(p => p.Id, _ => _id++)
            .RuleFor(p => p.TripId, f => f.PickRandom(routes).Id)
            .RuleFor(p => p.Name, f => f.Company.CompanyName())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.Point, f => $"{f.Address.Latitude()},{f.Address.Longitude()}")
            .RuleFor(p => p.Type, f => f.PickRandom<AdditionalPlaceType>())
            .Generate(count);
    }
}