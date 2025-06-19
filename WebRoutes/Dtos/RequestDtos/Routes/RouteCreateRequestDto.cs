using WebRoutes.Dtos.RequestDtos.AdditionalPlaces;
using WebRoutes.Dtos.RequestDtos.Places;
using WebRoutes.Enums;

namespace WebRoutes.Dtos.RequestDtos.Routes;

public class RouteCreateRequestDto
{
    public required int UserId { get; init; }
    
    public required string RouteTitle { get; init; }
    
    public string? RouteDescription { get; init; }
    
    public required RouteType RouteType { get; init; }
    
    public required DateTime CreatedAt { get; init; }
    
    public required ICollection<PlaceCreateRequestDto> PlacesInfos { get; init; }
    
    public ICollection<AdditionalPlaceCreateRequestDto>? AdditionalPlacesInfos { get; init; }
}