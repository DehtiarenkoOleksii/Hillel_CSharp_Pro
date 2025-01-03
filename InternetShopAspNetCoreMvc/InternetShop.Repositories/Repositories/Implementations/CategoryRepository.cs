using InternetShop.Data.Data;
using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Repositories.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InternetShopDbContext context) : base(context)
        {
        }
		public async Task<Category> GetCategoryWithProductsAsync(int id)
		{
			return await _context.Categories
				.Include(c => c.Products) 
				.FirstOrDefaultAsync(c => c.Id == id);
		}
	}
}
