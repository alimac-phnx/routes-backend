using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserWithRoutesAsync(int id);
    }
}