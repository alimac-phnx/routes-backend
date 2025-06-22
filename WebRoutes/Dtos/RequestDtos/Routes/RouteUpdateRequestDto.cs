using WebRoutes.Dtos.RequestDtos.AdditionalPlaces;
using WebRoutes.Dtos.RequestDtos.Places;
using WebRoutes.Enums;

namespace WebRoutes.Dtos.RequestDtos.Routes;

public class RouteUpdateRequestDto
{
    public string? RouteTitle { get; init; }
    
    public string? RouteDescription { get; init; }
    
    public RouteType? RouteType { get; init; }
    
    public ICollection<PlaceCreateRequestDto>? PlacesInfos { get; init; }
    
    public ICollection<AdditionalPlaceCreateRequestDto>? AdditionalPlacesInfos { get; init; }
}