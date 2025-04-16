using WebRoutes.Enums;

namespace WebRoutes.Models
{
    public class Media
    {
        public int Id { get; set; }
        
        public int ReviewId { get; set; }
        
        public MediaType Type { get; set; }
        
        public string Url { get; set; }
    }
}
