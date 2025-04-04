using Microsoft.AspNetCore.Mvc;
using WebRoutes.Services;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var route = await _routeService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoute(Route route)
        {
            await _routeService.CreateRouteAsync(route);
            return CreatedAtAction(nameof(GetRoute), new { id = route.Id }, route);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoute(int id, Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            await _routeService.UpdateRouteAsync(route);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoute(int id)
        {
            await _routeService.DeleteRouteAsync(id);
            return NoContent();
        }
    }

}