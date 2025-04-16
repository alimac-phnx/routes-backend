using System.Text.Json.Serialization;

namespace WebRoutes.Models
{
    public abstract class Location
    {
        public int Id { get; set; }
        
        public int PointId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Point Point { get; set; }

        [JsonIgnore]
        public ICollection<Route> Routes { get; set; }
    }
}