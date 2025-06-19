using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Services.Routes;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/routes")]
    [Authorize]
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
        public async Task<ActionResult<RoutePostResponseDto>> GetRoute(int id)
        {
            var route = await _routeService.GetRouteByIdAsync(id);
            
            if (route is null)
            {
                return NotFound("Route not found");
            }
            
            return Ok(route);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateRoute(RouteCreateRequestDto routeCreateRequest)
        {
            var response = await _routeService.CreateRouteByRequestAsync(routeCreateRequest);
            
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Route could not be created.");
            }
    
            return Ok("Route created successfully.");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateRoute(int id, RouteUpdateRequestDto routeUpdateRequest)
        {
            var response = await _routeService.UpdateRouteByRequestAsync(id, routeUpdateRequest);
            
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Route could not be updated.");
            }
            
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteRoute(int id)
        {
            await _routeService.DeleteRouteAsync(id);
            return NoContent();
        }
    }
}