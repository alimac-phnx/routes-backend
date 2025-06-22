using Coordinate = WebRoutes.Models.Coordinate;

namespace WebRoutes.Models;

public class Point
{
    public int Id { get; set; }
    
    public int LocationId { get; set; }
    
    public int CoordinateId { get; set; }
    
    public Coordinate Coordinate { get; set; }
}