using InternetShop.Data.Models;


namespace InternetShop.Services.Interfaces
{
    public interface ICategoryService : IBaseService<Category>
    {
		Task<Category> GetCategoryWithProductsAsync(int id);
	}
}
