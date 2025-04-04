using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                .AsNoTracking()
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetFollowersByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                .AsNoTracking()
                .Where(s => s.FollowedUserId == userId)
                .ToListAsync();
        }

        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }
    }
}