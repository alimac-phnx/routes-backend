using WebRoutes.Enums;

namespace WebRoutes.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TripId { get; set; }
        public MarkType MarkType { get; set; }
    }
}
