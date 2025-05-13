using WebRoutes.Enums;

namespace WebRoutes.Dtos.ResponseDtos.Route;

public class RouteInfoResponseDto
{
    public int RouteId { get; set; }
    
    public int UserId { get; set; }
    
    public string RouteTitle { get; set; }
    
    public string RouteDescription { get; set; }
    
    public RouteType RouteType { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public float RouteDistance { get; set; }
    
    public float RouteRating { get; set; }
    
    public bool IsFavorite { get; set; }
}