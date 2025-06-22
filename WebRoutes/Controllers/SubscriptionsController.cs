using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Services.Subscriptions;

namespace WebRoutes.Controllers;
[ApiController]
[Route("api/subscriptions")]
[Authorize]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionsController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionResponseDto>>> GetSubscriptions()
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync(currentUserId);
        
        return Ok(subscriptions);
    }

    [HttpGet("followers")]
    public async Task<ActionResult<IEnumerable<SubscriptionResponseDto>>> GetFollowers()
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var followers = await _subscriptionService.GetAllFollowersAsync(currentUserId);
        
        return Ok(followers);
    }

    [HttpPost("create/{followerId}")]
    public async Task<ActionResult> CreateSubscriptionAsync(int followeeId)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var response = await _subscriptionService.CreateSubscriptionAsync(currentUserId, followeeId);

        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("Subscription could not be created.");
        }
        
        return Ok("Subscription created successfully.");
    }

    [HttpDelete("delete/{followeeId}")]
    public async Task<ActionResult> DeleteSubscription(int followeeId)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var response = await _subscriptionService.DeleteSubscriptionAsync(currentUserId, followeeId);
        
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("This subscription does not exist.");
        }

        return NoContent();
    }
}