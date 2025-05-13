using Microsoft.EntityFrameworkCore;
using WebRoutes.Infrastructure;
using WebRoutes.Models;

namespace WebRoutes.Repositories.implementation
{
    internal class LocationRepository<T> : ILocationRepository<T> where T : Location
    {
        protected readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }

}