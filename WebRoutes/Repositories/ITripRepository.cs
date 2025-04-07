using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<IEnumerable<Trip>> GetRoutesWithDetailsAsync();

        Task UpdateRouteSimplifiedAsync(Trip trip);
    }
}