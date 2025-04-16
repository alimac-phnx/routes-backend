using Microsoft.EntityFrameworkCore;

namespace WebRoutes.Infrastructure.TestDataConfig;

public static class FakeDataSeeder
{
   public static void SeedSync(ApplicationDbContext db)
    {
        if (db.Users.Any()) return;

        const int count = 10;
        var users = UserFaker.GenerateMany(count);
        db.Users.AddRange(users);

        var routes = RouteFaker.GenerateMany(count, users);
        db.Routes.AddRange(routes);
        
        var points = PointFaker.GenerateMany(count);
        db.Points.AddRange(points);

        var places = PlaceFaker.GenerateMany(count, points);
        db.Places.AddRange(places);

        var additionalPlaces = AdditionalPlaceFaker.GenerateMany(count, points);
        db.AdditionalPlaces.AddRange(additionalPlaces);

        var reviews = ReviewFaker.GenerateMany(count, users, routes);
        db.Reviews.AddRange(reviews);

        var media = MediaFaker.GenerateMany(count, reviews);
        db.Medias.AddRange(media);

        var marks = MarkFaker.GenerateMany(count, users, routes);
        db.Marks.AddRange(marks);

        var subs = SubscriptionFaker.GenerateMany(count, users);
        db.Subscriptions.AddRange(subs);

        db.SaveChanges();
    }

    public static async Task SeedAsync(ApplicationDbContext db, CancellationToken cancellationToken)
    {
        if (await db.Users.AnyAsync(cancellationToken)) return;

        const int count = 10;
        var users = UserFaker.GenerateMany(count);
        await db.Users.AddRangeAsync(users, cancellationToken);

        var routes = RouteFaker.GenerateMany(count, users);
        await db.Routes.AddRangeAsync(routes, cancellationToken);
        
        var points = PointFaker.GenerateMany(count);
        await db.Points.AddRangeAsync(points, cancellationToken);

        var places = PlaceFaker.GenerateMany(count, points);
        await db.Places.AddRangeAsync(places, cancellationToken);

        var additionalPlaces = AdditionalPlaceFaker.GenerateMany(count, points);
        await db.AdditionalPlaces.AddRangeAsync(additionalPlaces, cancellationToken);

        var reviews = ReviewFaker.GenerateMany(count, users, routes);
        await db.Reviews.AddRangeAsync(reviews, cancellationToken);

        var media = MediaFaker.GenerateMany(count, reviews);
        await db.Medias.AddRangeAsync(media, cancellationToken);

        var marks = MarkFaker.GenerateMany(count, users, routes);
        await db.Marks.AddRangeAsync(marks, cancellationToken);

        var subs = SubscriptionFaker.GenerateMany(count, users);
        await db.Subscriptions.AddRangeAsync(subs, cancellationToken);

        await db.SaveChangesAsync(cancellationToken);
    }
}