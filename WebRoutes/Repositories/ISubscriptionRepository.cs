using WebRoutes.Dtos;
using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    internal interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserIdAsync(int userId);
        
        Task<IEnumerable<Subscription>> GetFollowersByUserIdAsync(int userId);

        Task AddSubscriptionAsync(Subscription subscription);
        Task RemoveSubscriptionAsync(Subscription subscription);
    }
}