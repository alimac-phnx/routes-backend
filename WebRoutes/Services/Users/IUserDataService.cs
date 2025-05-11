using WebRoutes.Models;

namespace WebRoutes.Services.Users
{
    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        
        Task<User?> GetUserByIdAsync(int id);

        Task<User?> GetUserByEmailAsync(string email);
        
        Task CreateUserAsync(User user);
        
        Task UpdateUserAsync(User user);
        
        Task DeleteUserAsync(int id);
    }
}
