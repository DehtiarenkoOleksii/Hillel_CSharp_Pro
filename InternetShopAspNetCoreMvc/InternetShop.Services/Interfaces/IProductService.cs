using InternetShop.Data.Models;

namespace InternetShop.Services.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task<string> GetImageNameAsync(int id);
        Task<List<Product>> GetByCategoryAsync(int categoryId);
    }
}
