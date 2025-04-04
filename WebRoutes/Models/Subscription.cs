namespace WebRoutes.Models
{
    public class Subscription
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public User FollowedUser { get; set; }

        public int FollowedUserId { get; set; }
    }
}