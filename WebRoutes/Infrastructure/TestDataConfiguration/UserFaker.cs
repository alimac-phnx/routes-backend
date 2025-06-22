using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

internal static class UserFaker
{
    public static ICollection<User> GenerateMany(int count)
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.SecondName, f => f.Name.FirstName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
            .RuleFor(u => u.ImageUrl, f => f.Image.PicsumUrl())
            .Generate(count);
    }
}