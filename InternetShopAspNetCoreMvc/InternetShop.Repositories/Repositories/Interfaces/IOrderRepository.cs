using InternetShop.Data.Models;

namespace InternetShop.Repositories.Repositories.Interfaces
{
	public interface IOrderRepository : IBaseRepository<Order>
	{
		Task<List<Order>> GetAllOrdersWithDetailsAsync();
		Task<List<Order>> GetUserOrdersWithDetailsAsync(int userId);
		Task<Order> GetOrderWithDetailsAsync(int id);
		Task ConfirmOrderAsync(int userId);
		Task DeleteOrderAsync(int id);
		Task UpdateOrderAsync(Order order);
        Task<List<User>> GetAllUsersAsync();
    }
}
