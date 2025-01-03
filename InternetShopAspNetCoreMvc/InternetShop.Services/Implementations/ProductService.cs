using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using InternetShop.Services.Interfaces;


namespace InternetShop.Services.Implementations
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> GetImageNameAsync(int id)
        {
            return await _productRepository.GetImageNameAsync(id);
        }

        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetByCategoryAsync(categoryId);
        }
    }
}
