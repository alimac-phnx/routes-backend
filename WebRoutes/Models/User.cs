using System.Text.Json.Serialization;

namespace WebRoutes.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string LastName { get; set; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        [JsonIgnore]
        public ICollection<Route>? Routes { get; set; }

        [JsonIgnore]
        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}