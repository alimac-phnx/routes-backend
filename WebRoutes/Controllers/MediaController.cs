using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("by-review/{reviewId}")]
        public async Task<ActionResult<IEnumerable<Media>>> GetMediaByReviewId(int reviewId)
        {
            var media = await _mediaService.GetMediaByReviewIdAsync(reviewId);
            return Ok(media);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMedia(Media media)
        {
            await _mediaService.CreateMediaAsync(media);
            return CreatedAtAction(nameof(GetMediaByReviewId), new { reviewId = media.ReviewId }, media);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedia(int id)
        {
            await _mediaService.DeleteMediaAsync(id);
            return NoContent();
        }
    }

}
