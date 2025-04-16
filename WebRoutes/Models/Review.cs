namespace WebRoutes.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public int RouteId { get; set; }
        
        public string Header { get; set; }
        
        public string Text { get; set; }
        
        public int Grade { get; set; }
        
        public DateTime DateUploaded { get; set; }
    }
}
