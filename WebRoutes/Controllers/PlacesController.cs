using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            var places = await _placeService.GetAllPlacesAsync();
            return Ok(places);
        }

        [HttpGet("ordered")]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlacesOrderedByVisit()
        {
            var places = await _placeService.GetPlacesOrderedByVisitAsync();
            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceById(int id)
        {
            var place = await _placeService.GetPlaceByIdAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlace(Place place)
        {
            await _placeService.CreatePlaceAsync(place);
            return CreatedAtAction(nameof(GetPlaceById), new { id = place.Id }, place);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlace(int id, Place place)
        {
            if (id != place.Id)
            {
                return BadRequest("ID в маршруте и теле запроса не совпадают.");
            }

            await _placeService.UpdatePlaceAsync(place);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlace(int id)
        {
            await _placeService.DeletePlaceAsync(id);
            return NoContent();
        }
    }
}