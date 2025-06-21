namespace WebRoutes.Models
{
    public class Subscription
    {
        public int Id { get; init; }
    
        public int SubscriberId { get; init; }
        
        public User Subscriber { get; init; }
    
        public int FolloweeId { get; init; }
        
        public User Followee { get; init; }
    }
}