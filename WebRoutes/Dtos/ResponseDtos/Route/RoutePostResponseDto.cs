using WebRoutes.Dtos.ResponseDtos.AdditionalPlace;
using WebRoutes.Dtos.ResponseDtos.Place;
using WebRoutes.Models;
using Point = WebRoutes.Models.Point;

namespace WebRoutes.Dtos.ResponseDtos.Route;

public class RoutePostResponseDto
{
    public RouteInfoResponseDto RouteInfo { get; init; }
    
    public string AuthorUsername { get; init; }
    
    public ICollection<PlaceInfoResponseDto> PlacesInfos { get; init; }
    
    public ICollection<AdditionalPlaceInfoResponseDto> AdditionalPlacesInfos { get; init; }
    
    public string RoutePathImageUrl { get; init; } //??
    
    public int RouteTime { get; init; } //??
    
    public ICollection<Review> Reviews { get; init; }
    
    public ICollection<Models.Point> RoutePath { get; init; } //??
}