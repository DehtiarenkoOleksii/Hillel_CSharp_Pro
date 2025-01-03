using InternetShop.Data.Models;


namespace InternetShop.Services.Interfaces
{
    public interface IOrderService : IBaseService<Order>
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
