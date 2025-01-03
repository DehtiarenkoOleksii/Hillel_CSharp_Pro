using InternetShop.Data.Data;
using InternetShop.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace InternetShop.Repositories.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InternetShopDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(InternetShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet
				.AsNoTracking()
				.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
		}

		public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

		public async Task UpdateAsync(T entity)
		{
			var key = _context.Entry(entity).Property("Id").CurrentValue;

			var existingEntity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == (int)key);

			if (existingEntity != null)
			{
				_context.Entry(existingEntity).State = EntityState.Detached;
			}

			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}



		public async Task DeleteAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);

			if (entity == null)
			{
				throw new KeyNotFoundException($"Entity with ID {id} not found.");
			}

			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
