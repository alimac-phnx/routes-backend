using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    internal interface ILocationRepository<T> where T : Location
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);
        
        Task AddAsync(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);
        
        Task SaveChangesAsync();
    }
}