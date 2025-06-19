using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Routes;
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
    private readonly IRouteValidationService _routeValidationService;
    private readonly IImageStorageService _imageStorageService;
    private readonly IRouteBuilder _routeBuilder;
    private readonly IMapper _mapper;

    public RouteService(IRouteDataService routeDataService,
        IRouteValidationService routeValidationService,
        IImageStorageService imageStorageService,
        IRouteBuilder routeBuilder,
        IMapper mapper)
    {
        _routeDataService = routeDataService;
        _routeValidationService = routeValidationService;
        _imageStorageService = imageStorageService;
        _routeBuilder = routeBuilder;
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

    public async Task<HttpResponseMessage> CreateRouteByRequestAsync(RouteCreateRequestDto routeCreateRequestDto)
    {
        var route = _mapper.Map<Route>(routeCreateRequestDto);
        if (!await _routeValidationService.IsRouteValid(route))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        var placesImages = routeCreateRequestDto.PlacesInfos
            .Select(pi => pi.LocationCreateInfo.LocationImage).ToList();
        var additionalPlacesImages = routeCreateRequestDto.AdditionalPlacesInfos?
            .Select(pi => pi.LocationCreateInfo.LocationImage).ToList();

        var placeImageUrls = placesImages.Select(placeImage =>
            placeImage != null ? _imageStorageService.UploadImageAsync(placeImage) : null).ToList();

        route.Places.ToList().ForEach(place => placeImageUrls.ForEach(imageUrl => place.ImageUrl = imageUrl ));
        
        var additionalPlacesImagesUrls = additionalPlacesImages?.Select(additionalPlaceImage =>
            additionalPlaceImage != null ? _imageStorageService.UploadImageAsync(additionalPlaceImage) : null).ToList();
        
        route.AdditionalPlaces?.ToList().ForEach(additionalPlace => additionalPlacesImagesUrls?
            .ForEach(imageUrl => additionalPlace.ImageUrl = imageUrl ));

        var routeInfo = await _routeBuilder.BuildAsync(route.Places.ToList());

        route.Length = routeInfo.distance;
        route.Duration = routeInfo.time;
        route.RoutePath = routeInfo.coordinates;
        
        await _routeDataService.CreateRouteAsync(route);
        
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

    public async Task DeleteRouteAsync(int id)
    {
        if (await _routeDataService.GetRouteByIdAsync(id) != null)
        {
            await _routeDataService.DeleteRouteAsync(id);
        }
    }
}