using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Services.Subscriptions;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<SubscriptionResponseDto>>> GetSubscriptions(int userId)
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync(userId);
            return Ok(subscriptions);
        }

        [HttpGet("followers/{userId}")]
        public async Task<ActionResult<IEnumerable<SubscriptionResponseDto>>> GetFollowers(int userId)
        {
            var followers = await _subscriptionService.GetAllFollowersAsync(userId);
            return Ok(followers);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscriptionAsync(int subscriberId, int followeeId)
        {
            var response = await _subscriptionService.CreateSubscriptionAsync(subscriberId, followeeId);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Subscription could not be created.");
            }
            
            return CreatedAtAction(nameof(GetSubscriptions), new { userId = subscriberId });
        }

        [HttpDelete("{subscriberId}/{followeeId}")]
        public async Task<ActionResult> DeleteSubscription(int subscriberId, int followeeId)
        {
            var response = await _subscriptionService.DeleteSubscriptionAsync(subscriberId, followeeId);
            
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("This subscription does not exist.");
            }

            return NoContent();
        }
    }
}