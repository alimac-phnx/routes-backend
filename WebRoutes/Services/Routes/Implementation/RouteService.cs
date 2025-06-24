using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Mappers;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes.Implementation;

internal class RouteService : IRouteService
{
    private readonly IRouteDataService _routeDataService;
    private readonly IRouteValidationService _routeValidationService;
    private readonly IRouteCreatingService _routeCreatingService;
    private readonly IRouteMapper _routeMapper;
    private readonly IMapper _mapper;

    public RouteService(IRouteDataService routeDataService,
        IRouteValidationService routeValidationService,
        IRouteCreatingService routeCreatingService,
        IRouteMapper routeMapper,
        IMapper mapper)
    {
        _routeDataService = routeDataService;
        _routeValidationService = routeValidationService;
        _routeCreatingService = routeCreatingService;
        _routeMapper = routeMapper;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<RouteCardResponseDto>> GetAllRoutesAsync(int userId, int pageNumber, int pageSize)
    {
        var routes = await _routeDataService.GetAllRoutesAsync(userId, pageNumber, pageSize);
        
        return _mapper.Map<IEnumerable<RouteCardResponseDto>>(routes);
    }

    public async Task<IEnumerable<RouteCardUserResponseDto>> GetAllRoutesForUserAsync(int id, int currentUserId, int pageNumber, int pageSize)
    {
        var routes = await _routeDataService.GetAllRoutesForUserAsync(id, currentUserId, pageNumber, pageSize);
        
        return _routeMapper.MapMarks(routes.ToList(), id, currentUserId);;
    }

    public async Task<RoutePostResponseDto> GetRouteByIdAsync(int id, int userId)
    {
        var route = await _routeDataService.GetRouteWithDetailsByIdAsync(id, userId);
        
        return _mapper.Map<RoutePostResponseDto>(route);
    }

    public async Task<HttpResponseMessage> CreateRouteByRequestAsync(RouteCreateRequestDto routeCreateRequestDto)
    {
        var route = _mapper.Map<Route>(routeCreateRequestDto);
        if (!await _routeValidationService.IsRouteValid(route))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        var routeData = await _routeCreatingService.CreateRouteDataAsync(routeCreateRequestDto, route);
        await _routeDataService.CreateRouteAsync(routeData);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
    

    public async Task<HttpResponseMessage> UpdateRouteByRequestAsync(int id, RouteUpdateRequestDto routeUpdateRequest)
    {
        var routeToUpdate = await _routeDataService.GetRouteByIdAsync(id);
        if (routeToUpdate == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        var route = _mapper.Map(routeUpdateRequest, routeToUpdate);
        await _routeDataService.UpdateRouteAsync(route);
        
        return new HttpResponseMessage(HttpStatusCode.OK);
    }

    public async Task<HttpResponseMessage> DeleteRouteAsync(int id)
    {
        if (await _routeDataService.GetRouteByIdAsync(id) == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        await _routeDataService.DeleteRouteAsync(id);
        
        return new HttpResponseMessage(HttpStatusCode.NoContent);
    }
}