using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation;

internal class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Review>> GetReviewsByRouteIdAsync(int routeId)
    {
        return await _context.Reviews
            .Where(r => r.RouteId == routeId)
            .ToListAsync();
    }
}