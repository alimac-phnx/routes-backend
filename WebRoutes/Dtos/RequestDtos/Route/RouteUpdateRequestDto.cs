using WebRoutes.Dtos.RequestDtos.AdditionalPlace;
using WebRoutes.Dtos.RequestDtos.Place;
using WebRoutes.Enums;

namespace WebRoutes.Dtos.RequestDtos.Route;

public class RouteUpdateRequestDto
{
    public string? RouteTitle { get; init; }
    
    public string? RouteDescription { get; init; }
    
    public RouteType? RouteType { get; init; }
    
    public ICollection<PlaceCreateRequestDto>? PlacesInfos { get; init; }
    
    public ICollection<AdditionalPlaceCreateRequestDto>? AdditionalPlacesInfos { get; init; }
}