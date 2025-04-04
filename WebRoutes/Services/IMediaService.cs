using WebRoutes.Models;

namespace WebRoutes.Services
{
    public interface IMediaService
    {
        Task<IEnumerable<Media>> GetMediaByReviewIdAsync(int reviewId);
        
        Task CreateMediaAsync(Media media);
        
        Task DeleteMediaAsync(int id);
    }
}