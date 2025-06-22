using Route = WebRoutes.Models.Route;
using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Enums;
using WebRoutes.Mappers;
using WebRoutes.Models;

namespace WebRoutes.Services.Routes.Implementation;

public class RouteCreatingService : IRouteCreatingService
{
    private readonly IImageStorageService _imageStorageService;
    private readonly IRouteBuilder _routeBuilder;
    private readonly IRouteMapper _routeMapper;

    public RouteCreatingService(
        IImageStorageService imageStorageService,
        IRouteBuilder routeBuilder,
        IRouteMapper routeMapper)
    {
        _imageStorageService = imageStorageService;
        _routeBuilder = routeBuilder;
        _routeMapper = routeMapper;
    }
    
    public async Task<Route> CreateRouteDataAsync(RouteCreateRequestDto routeCreateRequest, Route route)
    {
        SetImagesToRoutePlaces(routeCreateRequest, route);
        SetImagesToRouteAddtionalPlaces(routeCreateRequest, route);

        var routeInfo = await _routeBuilder.BuildAsync(route.Places.ToList());
        _routeMapper.MapInfo(route, routeInfo);
        
        route.Marks!.Add(new Mark
        {
            MarkType = MarkType.Mine,
            UserId = route.UserId,
        });

        return route;
    }

    private void SetImagesToRoutePlaces(RouteCreateRequestDto routeCreateRequest, Route route)
    {
        var placesImages = routeCreateRequest.PlacesInfos
            .Select(pi => pi.LocationCreateInfo.LocationImage).ToList();

        var placeImageUrls = placesImages.Select(placeImage =>
            placeImage != null ? _imageStorageService.UploadImageAsync(placeImage) : null).ToList();

        _routeMapper.MapPlaces(route, placeImageUrls);
    }

    private void SetImagesToRouteAddtionalPlaces(RouteCreateRequestDto routeCreateRequest, Route route)
    {
        var additionalPlacesImages = routeCreateRequest.AdditionalPlacesInfos?
            .Select(pi => pi.LocationCreateInfo.LocationImage).ToList();
        var additionalPlacesImagesUrls = additionalPlacesImages?.Select(additionalPlaceImage =>
            additionalPlaceImage != null ? _imageStorageService.UploadImageAsync(additionalPlaceImage) : null).ToList();
        
        _routeMapper.MapAdditionalPlaces(route, additionalPlacesImagesUrls);
    }
}