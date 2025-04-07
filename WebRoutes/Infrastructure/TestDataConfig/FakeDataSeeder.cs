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

        var trips = TripFaker.GenerateMany(count, users);
        db.Trips.AddRange(trips);

        var places = PlaceFaker.GenerateMany(count, trips);
        db.Places.AddRange(places);

        var additionalPlaces = AdditionalPlaceFaker.GenerateMany(count, trips);
        db.AddPlaces.AddRange(additionalPlaces);

        var reviews = ReviewFaker.GenerateMany(count, users, trips);
        db.Reviews.AddRange(reviews);

        var media = MediaFaker.GenerateMany(count, reviews);
        db.Media.AddRange(media);

        var marks = MarkFaker.GenerateMany(count, users, trips);
        db.Marks.AddRange(marks);

        // var subs = SubscriptionFaker.GenerateMany(count, users);
        // db.Subscriptions.AddRange(subs);

        db.SaveChanges();
    }

    public static async Task SeedAsync(ApplicationDbContext db, CancellationToken cancellationToken)
    {
        if (await db.Users.AnyAsync(cancellationToken)) return;

        const int count = 10;
        var users = UserFaker.GenerateMany(count);
        await db.Users.AddRangeAsync(users, cancellationToken);

        var trips = TripFaker.GenerateMany(count, users);
        await db.Trips.AddRangeAsync(trips, cancellationToken);

        var places = PlaceFaker.GenerateMany(count, trips);
        await db.Places.AddRangeAsync(places, cancellationToken);

        var additionalPlaces = AdditionalPlaceFaker.GenerateMany(count, trips);
        await db.AddPlaces.AddRangeAsync(additionalPlaces, cancellationToken);

        var reviews = ReviewFaker.GenerateMany(count, users, trips);
        await db.Reviews.AddRangeAsync(reviews, cancellationToken);

        var media = MediaFaker.GenerateMany(count, reviews);
        await db.Media.AddRangeAsync(media, cancellationToken);

        var marks = MarkFaker.GenerateMany(count, users, trips);
        await db.Marks.AddRangeAsync(marks, cancellationToken);

        // var subs = SubscriptionFaker.GenerateMany(count, users);
        // await db.Subscriptions.AddRangeAsync(subs, cancellationToken);

        await db.SaveChangesAsync(cancellationToken);
    }
}