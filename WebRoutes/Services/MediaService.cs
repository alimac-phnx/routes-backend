using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<Media>> GetMediaByReviewIdAsync(int reviewId)
        {
            return await _mediaRepository.GetMediaByReviewIdAsync(reviewId);
        }

        public async Task CreateMediaAsync(Media media)
        {
            await _mediaRepository.AddAsync(media);
            await _mediaRepository.SaveChangesAsync();
        }

        public async Task DeleteMediaAsync(int id)
        {
            var media = await _mediaRepository.GetByIdAsync(id);
            if (media != null)
            {
                _mediaRepository.Delete(media);
                await _mediaRepository.SaveChangesAsync();
            }
        }
    }
}
