using System.Linq.Expressions;


namespace InternetShop.Repositories.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
