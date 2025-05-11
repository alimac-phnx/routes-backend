using AutoMapper;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes.Implementation;

internal class RouteService : IRouteService
{
    private readonly IRouteDataService _routeDataService;
    private readonly IMapper _mapper;

    public RouteService(IRouteDataService routeDataService, IMapper mapper)
    {
        _routeDataService = routeDataService;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<RouteCardResponseDto>> GetAllRoutesAsync()
    {
        var routes = await _routeDataService.GetAllRoutesAsync();
        
        return _mapper.Map<IEnumerable<RouteCardResponseDto>>(routes);
    }

    public async Task<RoutePostResponseDto> GetRouteByIdAsync(int id)
    {
        var route = await _routeDataService.GetRouteByIdAsync(id);
        
        return _mapper.Map<RoutePostResponseDto>(route);
    }

    public Task<HttpResponseMessage> CreateRouteAsync(Route route)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRouteAsync(Route route)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRouteAsync(int id)
    {
        throw new NotImplementedException();
    }
}