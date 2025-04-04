using System.Text.Json.Serialization;

namespace WebRoutes.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        [JsonIgnore]
        public ICollection<Route> Routes { get; set; } = new List<Route>();

        [JsonIgnore]
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}