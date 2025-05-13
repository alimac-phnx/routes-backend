using Microsoft.AspNetCore.Mvc;
using WebRoutes.Enums;
using WebRoutes.Models;
using WebRoutes.Services;
using WebRoutes.Services.AdditionalPlaces;

namespace WebRoutes.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]
    public class AdditionalPlacesController : ControllerBase
    {
        private readonly IAdditionalPlaceDataService _additionalPlaceDataService;

        public AdditionalPlacesController(IAdditionalPlaceDataService additionalPlaceDataService)
        {
            _additionalPlaceDataService = additionalPlaceDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalPlace>>> GetAdditionalPlaces()
        {
            var additionalPlaces = await _additionalPlaceDataService.GetAllAdditionalPlacesAsync();
            return Ok(additionalPlaces);
        }

        [HttpGet("by-type/{type}")]
        public async Task<ActionResult<IEnumerable<AdditionalPlace>>> GetAdditionalPlacesByType(AdditionalPlaceType type)
        {
            var additionalPlaces = await _additionalPlaceDataService.GetAdditionalPlacesByTypeAsync(type);
            return Ok(additionalPlaces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalPlace>> GetAdditionalPlaceById(int id)
        {
            var additionalPlace = await _additionalPlaceDataService.GetAdditionalPlaceByIdAsync(id);
            if (additionalPlace == null)
            {
                return NotFound();
            }
            return Ok(additionalPlace);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdditionalPlace(AdditionalPlace additionalPlace)
        {
            await _additionalPlaceDataService.CreateAdditionalPlaceAsync(additionalPlace);
            return CreatedAtAction(nameof(GetAdditionalPlaceById), new { id = additionalPlace.Id }, additionalPlace);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdditionalPlace(int id, AdditionalPlace additionalPlace)
        {
            if (id != additionalPlace.Id)
            {
                return BadRequest("ID в маршруте и теле запроса не совпадают.");
            }

            await _additionalPlaceDataService.UpdateAdditionalPlaceAsync(additionalPlace);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdditionalPlace(int id)
        {
            await _additionalPlaceDataService.DeleteAdditionalPlaceAsync(id);
            return NoContent();
        }
    }*/
}