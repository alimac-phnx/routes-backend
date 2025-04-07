using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;

namespace WebRoutes.Controllers.Task1
{
    [ApiController]
    [Route("routes")]
    public class RoutesController : ControllerBase
    {
        private readonly ITripService _tripService;

        public RoutesController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetRoutes()
        {
            var routes = await _tripService.GetAllRoutesAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetRoute(int id)
        {
            var route = await _tripService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoute(Trip trip)
        {
            await _tripService.CreateRouteAsync(trip);
            return CreatedAtAction(nameof(GetRoute), new { id = trip.Id }, trip);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoute(int id, Trip trip)
        {
            if (id != trip.Id)
            {
                return BadRequest();
            }

            await _tripService.UpdateRouteAsync(trip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoute(int id)
        {
            await _tripService.DeleteRouteAsync(id);
            return NoContent();
        }
    }

}