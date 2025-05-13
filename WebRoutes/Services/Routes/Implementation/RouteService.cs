using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Route;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Models;
using WebRoutes.Services.AdditionalPlaces;
using WebRoutes.Services.Places;
using WebRoutes.Services.Users;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Services.Routes.Implementation;

internal class RouteService : IRouteService
{
    private readonly IRouteDataService _routeDataService;
    private readonly IImageStorageService _imageStorageService;
    private readonly IUserDataService _userDataService;
    private readonly IPlaceService _placeService;
    private readonly IAdditionalPlaceService _additionalPlaceService;
    private readonly IMapper _mapper;

    public RouteService(IRouteDataService routeDataService,
        IImageStorageService imageStorageService,
        IUserDataService userDataService,
        IPlaceService placeService,
        IAdditionalPlaceService additionalPlaceService,
        IMapper mapper)
    {
        _routeDataService = routeDataService;
        _imageStorageService = imageStorageService;
        _userDataService = userDataService;
        _placeService = placeService;
        _additionalPlaceService = additionalPlaceService;
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

    public async Task<HttpResponseMessage> CreateRouteAsync(RouteCreateRequestDto routeCreateRequestDto)
    {
        var route = _mapper.Map<Route>(routeCreateRequestDto);
        var user = await _userDataService.GetUserByIdAsync(route.UserId);
        if (await _routeDataService.GetRouteByIdAsync(route.Id) != null 
            || user == null 
            || routeCreateRequestDto.PlacesInfos.Count == 0)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        route.User = user;
        
        var placesDtos = routeCreateRequestDto.PlacesInfos.ToList(); 
        //places.ForEach(p => _placeService.CreatePlaceAsync(p));
        var places = placesDtos.Select(placeDto => _mapper.Map<Models.Place>(placeDto)).ToList();

        var additionalPlacesDtos = routeCreateRequestDto.AdditionalPlacesInfos?.ToList(); 
       //additionalPlaces?.ForEach(ap => _additionalPlaceService.CreateAdditionalPlaceAsync(ap));
       var additionalPlaces = additionalPlacesDtos?.Select(additionalPlaceDto => _mapper
           .Map<Models.AdditionalPlace>(additionalPlaceDto)).ToList();
        
        var placesImages = placesDtos
            .Select(pi => pi.LocationCreateInfo.LocationImage).ToList();
        var additionalPlacesImages = additionalPlacesDtos?
            .Select(pi => pi.LocationCreateInfo.LocationImage).ToList();

        var placeImageUrls = placesImages.Select(placeImage =>
            placeImage != null ? _imageStorageService.UploadImageAsync(placeImage) : null).ToList();

        for (int i = 0; i < places.Count; i++)
        {
            places[i].ImageUrl = placeImageUrls[i];
        }
        
        var additionalPlaceImageUrls = additionalPlacesImages?.Select(additionalPlaceImage =>
            additionalPlaceImage != null ? _imageStorageService.UploadImageAsync(additionalPlaceImage) : null).ToList();

        for (int i = 0; i < additionalPlaces?.Count; i++)
        {
            additionalPlaces[i].ImageUrl = additionalPlaceImageUrls?[i];
        }
        
        route.Places = places;
        route.AdditionalPlaces = additionalPlaces;
        
        await _routeDataService.CreateRouteAsync(route);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
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