using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Marks;
using WebRoutes.Models;

namespace WebRoutes.Services.Marks.Implementation;

public class MarkService : IMarkService
{
    private readonly IMarkDataService _markDataService;
    private readonly IMarkValidationService _markValidationService;
    private readonly IMapper _mapper;

    public MarkService(IMarkDataService markDataService, IMarkValidationService markValidationService, IMapper mapper)
    {
        _markDataService = markDataService;
        _markValidationService = markValidationService;
        _mapper = mapper;
    }
    
    public async Task<HttpResponseMessage> CreateMarkAsync(MarkCreateRequestDto markCreateRequest)
    {
        var mark = _mapper.Map<Mark>(markCreateRequest);
        if (!await _markValidationService.IsMarkValid(mark))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        await _markDataService.CreateMarkAsync(mark);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
    
    public async Task DeleteMarkAsync(int id)
    {
        var mark = await _markDataService.GetMarkByIdAsync(id);
        
        if (mark != null)
        {
            await _markDataService.DeleteMarkAsync(mark);
        }
    }
}