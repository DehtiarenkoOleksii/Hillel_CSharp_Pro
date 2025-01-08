using InternetShop.Contract.DTO;


namespace InternetShop.Services.Interfaces
{
	public interface IOrderItemService : IBaseService<OrderItemDto>
	{
		Task<List<OrderItemDto>> GetByOrderIdAsync(int orderId);
	}
}
