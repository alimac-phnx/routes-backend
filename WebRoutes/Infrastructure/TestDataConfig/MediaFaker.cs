using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class MediaFaker
{
    private static int _id = 1;

    public static List<Media> GenerateMany(int count, List<Review> reviews)
    {
        return new Faker<Media>()
            .RuleFor(m => m.Id, _ => _id++)
            .RuleFor(m => m.ReviewId, f => f.PickRandom(reviews).Id)
            .RuleFor(m => m.Type, f => f.PickRandom<MediaType>())
            .RuleFor(m => m.DataPath, f => f.Image.PicsumUrl())
            .Generate(count);
    }
}