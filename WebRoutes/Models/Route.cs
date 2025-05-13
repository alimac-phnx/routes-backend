using WebRoutes.Enums;

namespace WebRoutes.Models
{
    public class Route
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public RouteType Type { get; set; }
        
        public string? Description { get; set; }
        
        public float Length { get; set; }
        
        public TimeSpan Duration { get; set; }
        
        public RouteDifficulty Difficulty { get; set; }
        
        public float Rating { get; set; }
        
        public DateTime DateUploaded { get; set; }
        
        public ICollection<Place> Places { get; set; }
        
        public ICollection<AdditionalPlace>? AdditionalPlaces { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
        
        public ICollection<Mark> Marks { get; set; }
    }
}