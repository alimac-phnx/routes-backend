using NetTopologySuite.Geometries;

namespace WebRoutes.Models;

public class Point
{
    public int Id { get; set; }
    
    public int LocationId { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}