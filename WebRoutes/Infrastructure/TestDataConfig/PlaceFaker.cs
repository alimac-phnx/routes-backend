using Bogus;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Infrastructure.TestDataConfig;

/*порядок нужно генерить не только на основе количества точек, которые тут генерятся,
 а ещё и на основе их принадлежности к одному трипу. То есть разбивать их по кучкам
 SELECT WHERE Place.TriPID = Place.TRIPID и тогда выбиратся порядок из количества вхождений
*/
internal class PlaceFaker
{
    public static ICollection<Place> GenerateMany(int count, ICollection<Point> points)
    {
        var randomOrders = Enumerable.Range(1, count)
            .OrderBy(x => Guid.NewGuid())
            .ToList();
        int orderIndex = 0;
        
        return new Faker<Place>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.RouteId, f => f.Random.Int(1, count))
            .RuleFor(p => p.Name, f => f.Address.City())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.PointId, f => points.Single(s => s.Id == f.IndexFaker + 1).Id)
            .FinishWith((f, p) => 
            {
                p.OrderOfVisit = randomOrders[orderIndex];
                orderIndex++;
            })
            .Generate(count);
    }
}