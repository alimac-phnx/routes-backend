using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos.Marks;
using WebRoutes.Services.Marks;

namespace WebRoutes.Controllers;

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
    public async Task<ActionResult> CreateMark(MarkCreateRequestDto markCreateRequest)
    {
        var response = await _markService.CreateMarkAsync(markCreateRequest);
            
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("Mark could not be created.");
        }
    
        return Ok("Mark created successfully.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteMark(int id)
    {
        var response = await _markService.DeleteMarkAsync(id);
        
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("This mark does not exist.");
        }

        return NoContent();
    }
}