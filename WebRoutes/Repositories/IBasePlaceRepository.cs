using WebRoutes.Models;

namespace WebRoutes.Repositories
{
    public interface IBasePlaceRepository<T> where T : BasePlace
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);
        
        Task AddAsync(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);
        
        Task SaveChangesAsync();
    }
}