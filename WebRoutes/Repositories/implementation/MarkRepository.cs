using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation
{
    public class MarkRepository : Repository<Mark>, IMarkRepository
    {
        public MarkRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Mark>> GetMarksByUserIdAsync(int userId)
        {
            return await _context.Marks
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> GetMarksByRouteIdAsync(int routeId)
        {
            return await _context.Marks
                .Where(m => m.TripId == routeId)
                .ToListAsync();
        }
    }
}