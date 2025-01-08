using InternetShop.Contract.DTO;


namespace InternetShop.Services.Interfaces
{
	public interface IOrderService : IBaseService<OrderDto>
	{
		Task<List<OrderDto>> GetByCustomerIdAsync(int customerId);
		Task<OrderDto?> GetByIdWithItemsAsync(int id);
	}
}
