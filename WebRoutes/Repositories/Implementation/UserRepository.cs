using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> GetUserWithRoutesAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Routes)
                .Include(u => u.Subscriptions)!
                .ThenInclude(s => s.Followee)
                .Include(u => u.Marks)!
                .ThenInclude(m => m.Route)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<User?> GetUserProfileAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Subscriptions)!
                .ThenInclude(s => s.Followee)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}