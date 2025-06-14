using WebRoutes.Enums;

namespace WebRoutes.Models
{
    public class Route
    {
        public int Id { get; init; }

        public int UserId { get; init; }

        public required User User { get; init; }

        public required string Name { get; init; }

        public RouteType Type { get; init; }
        
        public string? Description { get; init; }
        
        public float Length { get; set; }
        
        public float Duration { get; set; }
        
        public ICollection<Coordinate>? RoutePath { get; set; }
        
        public RouteDifficulty Difficulty { get; init; }
        
        public float Rating { get; init; }
        
        public DateTime DateUploaded { get; init; }
        
        public required ICollection<Place> Places { get; init; }
        
        public ICollection<AdditionalPlace>? AdditionalPlaces { get; init; }
        
        public ICollection<Review>? Reviews { get; init; }
        
        public ICollection<Mark>? Marks { get; init; }
    }
}