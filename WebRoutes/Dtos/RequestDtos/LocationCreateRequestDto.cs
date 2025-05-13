namespace WebRoutes.Dtos.RequestDtos;

public class LocationCreateRequestDto
{
    public required string LocationName { get; init; }
    
    public string? LocationDescription { get; init; }
    
    public required double Latitude { get; init; }
    
    public required double Longitude { get; init; }
    
    public IFormFile? LocationImage { get; init; }
}