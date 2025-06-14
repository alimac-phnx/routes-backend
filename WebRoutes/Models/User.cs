using System.Text.Json.Serialization;

namespace WebRoutes.Models
{
    public class User
    {
        public int Id { get; init; }

        public string Username { get; init; }

        public string? LastName { get; init; }

        public string? FirstName { get; init; }

        public string? SecondName { get; init; }
        
        public string Email { get; init; }
        
        public string PasswordHash { get; set; }
        
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<Route>? Routes { get; init; }

        [JsonIgnore]
        public ICollection<Subscription>? Subscriptions { get; init; }
        
        [JsonIgnore]
        public ICollection<Mark>? Marks { get; set; }
    }
}