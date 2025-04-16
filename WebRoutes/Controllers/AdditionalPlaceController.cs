using Microsoft.AspNetCore.Mvc;
using WebRoutes.Enums;
using WebRoutes.Models;
using WebRoutes.Services;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdditionalPlacesController : ControllerBase
    {
        private readonly IAdditionalPlaceService _additionalPlaceService;

        public AdditionalPlacesController(IAdditionalPlaceService additionalPlaceService)
        {
            _additionalPlaceService = additionalPlaceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalPlace>>> GetAdditionalPlaces()
        {
            var additionalPlaces = await _additionalPlaceService.GetAllAdditionalPlacesAsync();
            return Ok(additionalPlaces);
        }

        [HttpGet("by-type/{type}")]
        public async Task<ActionResult<IEnumerable<AdditionalPlace>>> GetAdditionalPlacesByType(AdditionalPlaceType type)
        {
            var additionalPlaces = await _additionalPlaceService.GetAdditionalPlacesByTypeAsync(type);
            return Ok(additionalPlaces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalPlace>> GetAdditionalPlaceById(int id)
        {
            var additionalPlace = await _additionalPlaceService.GetAdditionalPlaceByIdAsync(id);
            if (additionalPlace == null)
            {
                return NotFound();
            }
            return Ok(additionalPlace);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdditionalPlace(AdditionalPlace additionalPlace)
        {
            await _additionalPlaceService.CreateAdditionalPlaceAsync(additionalPlace);
            return CreatedAtAction(nameof(GetAdditionalPlaceById), new { id = additionalPlace.Id }, additionalPlace);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdditionalPlace(int id, AdditionalPlace additionalPlace)
        {
            if (id != additionalPlace.Id)
            {
                return BadRequest("ID в маршруте и теле запроса не совпадают.");
            }

            await _additionalPlaceService.UpdateAdditionalPlaceAsync(additionalPlace);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdditionalPlace(int id)
        {
            await _additionalPlaceService.DeleteAdditionalPlaceAsync(id);
            return NoContent();
        }
    }
}