using InternetShop.Data.Data;
using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Repositories.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly InternetShopDbContext _context;

        public ProductRepository(InternetShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetImageNameAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product?.Image ?? "no-image.jpg";
        }

        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
