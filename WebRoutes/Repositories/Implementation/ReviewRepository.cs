using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation;

internal class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Review>> GetReviewsByRouteIdAsync(int routeId, int pageNumber, int pageSize)
    {
        return await _context.Reviews
            .Where(r => r.RouteId == routeId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}