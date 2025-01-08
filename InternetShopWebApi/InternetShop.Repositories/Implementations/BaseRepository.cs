using InternetShop.Data.Context;
using InternetShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Repositories.Implementations
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly InternetShopDBContext _context;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(InternetShopDBContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public virtual async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public virtual async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public virtual async Task<T> CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<T> UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<bool> DeleteByIdAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity == null)
				return false;

			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public IQueryable<T> GetQueryable()
		{
			return _dbSet.AsQueryable();
		}
	}
}
