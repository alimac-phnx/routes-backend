using Microsoft.EntityFrameworkCore;

namespace WebRoutes.Infrastructure.TestDataConfig;

internal static class FakeDataSeeder
{
   public static void SeedSync(ApplicationDbContext db)
    {
        if (db.Users.Any()) return;

        const int count = 10;
        var users = UserFaker.GenerateMany(count);
        db.Users.AddRange(users);

        var routes = RouteFaker.GenerateMany(count, users);
        db.Routes.AddRange(routes);
        routes.ToList().ForEach(p => Console.WriteLine($"routes: {p.Id}"));
        
        var placePoints = PointFaker.GenerateMany(count);
        db.Points.AddRange(placePoints);
        placePoints.ToList().ForEach(p => Console.WriteLine(p.Id));
        var additionalPlacePoints = PointFaker.GenerateMany(count);
        db.Points.AddRange(additionalPlacePoints);
        additionalPlacePoints.ToList().ForEach(p => Console.WriteLine(p.Id));

        var places = PlaceFaker.GenerateMany(count, placePoints);
        db.Places.AddRange(places);
        places.ToList().ForEach(p => Console.WriteLine($"places: {p.Id} : routeID {p.RouteId}"));
        
        var additionalPlaces = AdditionalPlaceFaker.GenerateMany(count, additionalPlacePoints);
        db.AdditionalPlaces.AddRange(additionalPlaces);
        additionalPlaces.ToList().ForEach(p => Console.WriteLine($"addplaces: {p.Id} : routeID {p.RouteId}"));

        var reviews = ReviewFaker.GenerateMany(count, users);
        db.Reviews.AddRange(reviews);
        reviews.ToList().ForEach(p => Console.WriteLine($"reviews: {p.Id}"));

        var marks = MarkFaker.GenerateMany(count, users, routes);
        db.Marks.AddRange(marks);
        marks.ToList().ForEach(p => Console.WriteLine($"marks: {p.Id}"));

        var subs = SubscriptionFaker.GenerateMany(count, users);
        db.Subscriptions.AddRange(subs);
        subs.ToList().ForEach(p => Console.WriteLine($"subs: {p.SubscriberId}"));

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
        
        var placePoints = PointFaker.GenerateMany(count);
        db.Points.AddRange(placePoints);
        var additionalPlacePoints = PointFaker.GenerateMany(count);
        db.Points.AddRange(additionalPlacePoints);

        var places = PlaceFaker.GenerateMany(count, placePoints);
        await db.Places.AddRangeAsync(places, cancellationToken);
        
        var additionalPlaces = AdditionalPlaceFaker.GenerateMany(count, additionalPlacePoints);
        await db.AdditionalPlaces.AddRangeAsync(additionalPlaces, cancellationToken);

        var reviews = ReviewFaker.GenerateMany(count, users);
        await db.Reviews.AddRangeAsync(reviews, cancellationToken);

        var marks = MarkFaker.GenerateMany(count, users, routes);
        await db.Marks.AddRangeAsync(marks, cancellationToken);

        var subs = SubscriptionFaker.GenerateMany(count, users);
        await db.Subscriptions.AddRangeAsync(subs, cancellationToken);

        await db.SaveChangesAsync(cancellationToken);
    }
}