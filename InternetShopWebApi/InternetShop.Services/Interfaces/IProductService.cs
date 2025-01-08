using InternetShop.Contract.DTO;


namespace InternetShop.Services.Interfaces
{
	public interface IProductService : IBaseService<ProductDto>
	{
		Task<List<ProductDto>> GetByCategoryAsync(int categoryId);
	}
}
