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
    public async Task<ActionResult<IEnumerable<ReviewResponseDto>>> GetRouteReviews(int id)
    {
        var reviews = await _reviewService.GetReviewsByRouteAsync(id);
            
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
        await _reviewService.DeleteReviewAsync(id);
        return NoContent();
    }
}