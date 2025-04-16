using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class UserFaker
{
    private static int _id = 1;

    public static ICollection<User> GenerateMany(int count)
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, _ => _id++)
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.SecondName, f => f.Name.FirstName())
            .Generate(count);
    }
}