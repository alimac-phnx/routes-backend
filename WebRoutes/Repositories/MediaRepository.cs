using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public class MediaRepository : Repository<Media>, IMediaRepository
    {
        public MediaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Media>> GetMediaByReviewIdAsync(int reviewId)
        {
            return await _context.Media
                .Where(m => m.ReviewId == reviewId)
                .ToListAsync();
        }
    }
}
