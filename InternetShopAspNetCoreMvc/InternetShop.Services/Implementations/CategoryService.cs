using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using InternetShop.Services.Interfaces;


namespace InternetShop.Services.Implementations
{
	public class CategoryService : BaseService<Category>, ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<Category> GetCategoryWithProductsAsync(int id)
		{
			return await _categoryRepository.GetCategoryWithProductsAsync(id);
		}
	}
}
