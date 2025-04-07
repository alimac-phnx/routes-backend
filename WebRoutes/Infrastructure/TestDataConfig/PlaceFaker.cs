using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfig;


/*порядок нужно генерить не только на основе количества точек, которые тут генерятся,
 а ещё и на основе их принадлежности к одному трипу. То есть разбивать их по кучкам
 SELECT WHERE Place.TriPID = Place.TRIPID и тогда выбиратся порядок из количества вхождений
*/
public static class PlaceFaker
{
    private static int _id = 1;

    public static List<Place> GenerateMany(int count, List<Trip> routes)
    {
        var randomOrders = Enumerable.Range(1, count)
            .OrderBy(x => Guid.NewGuid()) // Перемешиваем числа
            .ToList();
        int orderIndex = 0;
        
        return new Faker<Place>()
            .RuleFor(p => p.Id, _ => _id++)
            .RuleFor(p => p.TripId, f => f.PickRandom(routes).Id)
            .RuleFor(p => p.Name, f => f.Address.City())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.Point, f => $"{f.Address.Latitude()},{f.Address.Longitude()}")
            .FinishWith((f, p) => 
            {
                p.OrderOfVisit = randomOrders[orderIndex];
                orderIndex++;
            })
            .Generate(count);
    }
}