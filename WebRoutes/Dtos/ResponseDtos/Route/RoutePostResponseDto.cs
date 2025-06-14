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
    
    public int RouteDuration { get; init; }
    
    public ICollection<Review> Reviews { get; init; }
    
    public ICollection<Coordinate> RoutePath { get; init; }
}