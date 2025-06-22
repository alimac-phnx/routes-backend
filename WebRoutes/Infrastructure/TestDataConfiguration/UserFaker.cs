using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

internal static class UserFaker
{
    public static ICollection<User> GenerateMany(int count)
    {
        var imageUrls = new[]
        {
            "https://res.cloudinary.com/dhpns0wlf/image/upload/v1750544977/%D0%BC%D1%83%D0%B6%D1%81%D0%BA%D0%BE%D0%B9_zy0gv8.png",
            "https://res.cloudinary.com/dhpns0wlf/image/upload/v1750544965/%D0%B6%D0%B5%D0%BD%D1%81%D0%BA%D0%B8%D0%B9_jgw1l8.png",
        };
        
        return new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.SecondName, f => f.Name.FirstName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PasswordHash, f => BCrypt.Net.BCrypt.HashPassword("123"))
            .RuleFor(u => u.ImageUrl, f => f.PickRandom(imageUrls))
            .Generate(count);
    }
}