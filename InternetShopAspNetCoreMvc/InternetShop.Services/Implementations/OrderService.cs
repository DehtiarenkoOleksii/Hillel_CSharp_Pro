using InternetShop.Data.Models;
using InternetShop.Services.Interfaces;
using InternetShop.Repositories.Repositories.Interfaces;


namespace InternetShop.Services.Implementations
{
	public class OrderService : BaseService<Order>, IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository) : base(orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<List<Order>> GetAllOrdersWithDetailsAsync()
		{
			return await _orderRepository.GetAllOrdersWithDetailsAsync();
		}

		public async Task<List<Order>> GetUserOrdersWithDetailsAsync(int userId)
		{
			return await _orderRepository.GetUserOrdersWithDetailsAsync(userId);
		}

		public async Task<Order> GetOrderWithDetailsAsync(int id)
		{
			return await _orderRepository.GetOrderWithDetailsAsync(id);
		}

		public async Task ConfirmOrderAsync(int userId)
		{
			await _orderRepository.ConfirmOrderAsync(userId);
		}

		public async Task DeleteOrderAsync(int id)
		{
			await _orderRepository.DeleteOrderAsync(id);
		}
		public async Task UpdateOrderAsync(Order order)
		{
			await _orderRepository.UpdateOrderAsync(order);
		}
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _orderRepository.GetAllUsersAsync();
        }
    }
}
