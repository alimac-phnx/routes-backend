namespace WebRoutes.Models
{
    public class Subscription
    {
        public int Id { get; set; }
    
        public int SubscriberId { get; set; }
        
        public User? Subscriber { get; set; }
    
        public int FolloweeId { get; set; }
        
        public User? Followee { get; set; }
    }
}