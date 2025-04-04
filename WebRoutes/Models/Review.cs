namespace WebRoutes.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public string Header { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Grade { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
