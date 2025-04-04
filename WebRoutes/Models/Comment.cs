namespace WebRoutes.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
