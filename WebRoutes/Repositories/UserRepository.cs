using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> GetUserWithRoutesAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Routes)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}