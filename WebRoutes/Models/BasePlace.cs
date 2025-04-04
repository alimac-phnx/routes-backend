using System.Text.Json.Serialization;

namespace WebRoutes.Models
{
    public abstract class BasePlace
    {
        public int Id { get; set; }
        
        public int RouteId { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Point { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}