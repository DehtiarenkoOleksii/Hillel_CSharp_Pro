using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T?> GetByIdAsync(int id);
		Task<List<T>> GetAllAsync();
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<bool> DeleteByIdAsync(int id);
		IQueryable<T> GetQueryable();
	}
}
