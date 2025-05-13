using Microsoft.AspNetCore.Mvc;
using WebRoutes.Models;
using WebRoutes.Services;
using WebRoutes.Services.Places;

namespace WebRoutes.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceDataService _placeDataService;

        public PlacesController(IPlaceDataService placeDataService)
        {
            _placeDataService = placeDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            var places = await _placeDataService.GetAllPlacesAsync();
            return Ok(places);
        }

        [HttpGet("ordered")]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlacesOrderedByVisit()
        {
            var places = await _placeDataService.GetPlacesOrderedByVisitAsync();
            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceById(int id)
        {
            var place = await _placeDataService.GetPlaceByIdAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlace(Place place)
        {
            await _placeDataService.CreatePlaceAsync(place);
            return CreatedAtAction(nameof(GetPlaceById), new { id = place.Id }, place);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlace(int id, Place place)
        {
            if (id != place.Id)
            {
                return BadRequest("ID в маршруте и теле запроса не совпадают.");
            }

            await _placeDataService.UpdatePlaceAsync(place);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlace(int id)
        {
            await _placeDataService.DeletePlaceAsync(id);
            return NoContent();
        }
    }*/
}