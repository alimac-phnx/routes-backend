using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/marks")]
    [Authorize]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _markService;

        public MarksController(IMarkService markService)
        {
            _markService = markService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateMark(Mark mark)
        {
            await _markService.CreateMarkAsync(mark);
            return Ok();
        }

        [HttpDelete("delete/{userId}/{routeId}")]
        public async Task<ActionResult> DeleteMark(int userId, int routeId)
        {
            await _markService.DeleteMarkAsync(userId, routeId);
            return NoContent();
        }
    }
}