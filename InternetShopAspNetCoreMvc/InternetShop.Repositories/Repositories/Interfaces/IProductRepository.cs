using InternetShop.Data.Models;

namespace InternetShop.Repositories.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<string> GetImageNameAsync(int id);
        Task<List<Product>> GetByCategoryAsync(int categoryId);
    }
}
