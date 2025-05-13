using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos.Route;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Services.Routes;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteCardResponseDto>>> GetRoutes()
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
        public async Task<ActionResult> CreateRoute(RouteCreateRequestDto route)
        {
            var response = await _routeService.CreateRouteAsync(route);
            
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Route could not be created.");
            }
    
            return NoContent();
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