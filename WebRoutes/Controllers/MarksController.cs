using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _markService;

        public MarksController(IMarkService markService)
        {
            _markService = markService;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Mark>>> GetMarksByUser(int userId)
        {
            var marks = await _markService.GetMarksByUserAsync(userId);
            return Ok(marks);
        }

        [HttpGet("route/{routeId}")]
        public async Task<ActionResult<IEnumerable<Mark>>> GetMarksByRoute(int routeId)
        {
            var marks = await _markService.GetMarksByRouteAsync(routeId);
            return Ok(marks);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMark(Mark mark)
        {
            await _markService.CreateMarkAsync(mark);
            return CreatedAtAction(nameof(GetMarksByRoute), new { routeId = mark.RouteId }, mark);
        }

        [HttpDelete("{userId}/{routeId}")]
        public async Task<ActionResult> DeleteMark(int userId, int routeId)
        {
            await _markService.DeleteMarkAsync(userId, routeId);
            return NoContent();
        }
    }
}