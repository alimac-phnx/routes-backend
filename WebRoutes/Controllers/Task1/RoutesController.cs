using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;
using Route = WebRoutes.Models.Route;

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
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            var routes = await _tripService.GetAllRoutesAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var route = await _tripService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoute(Route route)
        {
            await _tripService.CreateRouteAsync(route);
            return CreatedAtAction(nameof(GetRoute), new { id = route.Id }, route);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoute(int id, Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            await _tripService.UpdateRouteAsync(route);
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