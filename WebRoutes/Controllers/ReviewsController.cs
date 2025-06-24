using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos.Reviews;
using WebRoutes.Dtos.ResponseDtos.Reviews;
using WebRoutes.Services.Reviews;

namespace WebRoutes.Controllers;

[ApiController]
[Route("api/reviews")]
[Authorize]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
        
    [HttpGet("route/{id}")]
    public async Task<ActionResult<IEnumerable<ReviewResponseDto>>> GetRouteReviews(int id, int pageNumber = 1, int pageSize = 10)
    {
        var reviews = await _reviewService.GetReviewsByRouteAsync(id, pageNumber, pageSize);
            
        return Ok(reviews);
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateReview(ReviewCreateRequestDto reviewCreateRequest)
    {
        var response = await _reviewService.CreateReviewAsync(reviewCreateRequest);
            
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("Review could not be created.");
        }
    
        return Ok("Review created successfully.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteReview(int id)
    {
        var response = await _reviewService.DeleteReviewAsync(id);
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("This review does not exist.");
        }

        return NoContent();
    }
}