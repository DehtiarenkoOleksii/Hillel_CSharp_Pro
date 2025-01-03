using InternetShop.Data.Models;

namespace InternetShop.Repositories.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
		Task<Category> GetCategoryWithProductsAsync(int id);
	}
}
