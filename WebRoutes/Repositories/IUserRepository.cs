using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    internal interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserWithRoutesAsync(int id);

        Task<User?> GetUserByEmailAsync(string email);
    }
}