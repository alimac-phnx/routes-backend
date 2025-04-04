using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public interface IMediaRepository : IRepository<Media>
    {
        Task<IEnumerable<Media>> GetMediaByReviewIdAsync(int reviewId);
    }
}