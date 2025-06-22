namespace WebRoutes.Models
{
    public class Review
    {
        public int Id { get; init; }
        
        public int UserId { get; init; }
        
        public int RouteId { get; init; }
        
        public string Text { get; init; }
        
        public int Grade { get; init; }
    }
}
