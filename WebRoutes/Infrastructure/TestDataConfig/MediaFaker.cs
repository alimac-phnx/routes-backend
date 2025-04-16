using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class MediaFaker
{
    private static int _id = 1;

    public static ICollection<Media> GenerateMany(int count, ICollection<Review> reviews)
    {
        return new Faker<Media>()
            .RuleFor(m => m.Id, _ => _id++)
            .RuleFor(m => m.ReviewId, f => f.PickRandom(reviews).Id)
            .RuleFor(m => m.Type, f => f.PickRandom<MediaType>())
            .RuleFor(m => m.Url, f => f.Image.PicsumUrl())
            .Generate(count);
    }
}