namespace WebRoutes.Dtos.ResponseDtos.Place;

public class PlaceInfoResponseDto
{
    public LocationInfoResponseDto LocationInfo { get; set; }
    
    public int? OrderOfVisit { get; set; }
}