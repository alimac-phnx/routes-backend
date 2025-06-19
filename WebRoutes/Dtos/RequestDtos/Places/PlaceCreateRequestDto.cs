namespace WebRoutes.Dtos.RequestDtos.Places;

public class PlaceCreateRequestDto
{
    public required LocationCreateRequestDto LocationCreateInfo { get; init; }
    
    public int? OrderOfVisit { get; init; }
}