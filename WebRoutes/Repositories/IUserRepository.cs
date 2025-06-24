using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    internal interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetWithPaginationAllAsync(int pageNumber, int pageSize);
        
        Task<User?> GetUserWithRoutesAsync(int id);

        Task<User?> GetUserProfileAsync(int id);

        Task<User?> GetUserByEmailAsync(string email);
    }
}