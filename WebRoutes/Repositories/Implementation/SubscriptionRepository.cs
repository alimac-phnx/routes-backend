using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                .AsNoTracking()
                .Where(s => s.SubscriberId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetFollowersByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                .AsNoTracking()
                .Where(s => s.FolloweeId == userId)
                .ToListAsync();
        }

        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSubscriptionAsync(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }
    }
}