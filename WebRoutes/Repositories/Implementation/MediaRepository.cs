using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation
{
    internal class MediaRepository : Repository<Media>, IMediaRepository
    {
        public MediaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Media>> GetMediaByReviewIdAsync(int reviewId)
        {
            return await _context.Medias
                .Where(m => m.ReviewId == reviewId)
                .ToListAsync();
        }
    }
}
