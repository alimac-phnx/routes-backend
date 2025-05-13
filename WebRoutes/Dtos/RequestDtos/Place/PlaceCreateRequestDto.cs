namespace WebRoutes.Dtos.RequestDtos.Place;

public class PlaceCreateRequestDto
{
    public required LocationCreateRequestDto LocationCreateInfo { get; init; }
    
    public int? OrderOfVisit { get; init; }
}