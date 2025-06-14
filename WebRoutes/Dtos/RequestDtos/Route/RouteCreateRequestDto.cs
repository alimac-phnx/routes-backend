using System.ComponentModel.DataAnnotations;
using WebRoutes.Dtos.RequestDtos.AdditionalPlace;
using WebRoutes.Dtos.RequestDtos.Place;
using WebRoutes.Dtos.ResponseDtos.AdditionalPlace;
using WebRoutes.Dtos.ResponseDtos.Place;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Dtos.RequestDtos.Route;

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