using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;

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
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions(int userId)
        {
            var subscriptions = await _subscriptionService.GetSubscriptionsAsync(userId);
            return Ok(subscriptions);
        }

        [HttpGet("followers/{userId}")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetFollowers(int userId)
        {
            var followers = await _subscriptionService.GetFollowersAsync(userId);
            return Ok(followers);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscription(Subscription subscription)
        {
            await _subscriptionService.CreateSubscriptionAsync(subscription);
            return CreatedAtAction(nameof(GetSubscriptions), new { userId = subscription.UserId }, subscription);
        }

        [HttpDelete("{userId}/{followedUserId}")]
        public async Task<ActionResult> DeleteSubscription(int userId, int followedUserId)
        {
            await _subscriptionService.DeleteSubscriptionAsync(userId, followedUserId);
            return NoContent();
        }
    }
}