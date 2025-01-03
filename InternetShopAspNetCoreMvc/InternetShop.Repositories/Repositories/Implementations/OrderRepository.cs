using InternetShop.Data.Data;
using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Repositories.Repositories.Implementations
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		private readonly InternetShopDbContext _context;

		public OrderRepository(InternetShopDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Order>> GetAllOrdersWithDetailsAsync()
		{
			return await _context.Orders
				.Include(o => o.OrderDetails)
				.ThenInclude(od => od.Product)
				.ToListAsync();
		}

		public async Task<List<Order>> GetUserOrdersWithDetailsAsync(int userId)
		{
			return await _context.Orders
				.Include(o => o.OrderDetails)
				.Where(o => o.UserId == userId)
				.ToListAsync();
		}

		public async Task<Order> GetOrderWithDetailsAsync(int id)
		{
			return await _context.Orders
				.Include(o => o.OrderDetails) 
				.ThenInclude(od => od.Product)
				.FirstOrDefaultAsync(o => o.Id == id);
		}

		public async Task ConfirmOrderAsync(int userId)
		{
			var cartItems = await _context.CartItems
				.Where(c => c.UserId == userId)
				.Include(c => c.Product) 
				.ToListAsync();

			
			if (cartItems.Any(c => c.Product == null))
			{
				throw new Exception("One or more products in the cart are no longer available");
			}

			var order = new Order
			{
				UserId = userId,
				CreatedAt = DateTime.UtcNow,
				Amount = cartItems.Sum(c => c.Quantity * c.Product.Price),
				OrderDetails = cartItems.Select(c => new OrderDetail
				{
					ProductId = c.ProductId,
					Quantity = c.Quantity,
					Price = c.Product.Price,
					Total = c.Quantity * c.Product.Price
				}).ToList()
			};

			_context.Orders.Add(order);
			_context.CartItems.RemoveRange(cartItems);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteOrderAsync(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order != null)
			{
				_context.Orders.Remove(order);
				await _context.SaveChangesAsync();
			}
		}
		public async Task UpdateOrderAsync(Order order)
		{
			var existingOrder = await _context.Orders
				.Include(o => o.User)
				.Include(o => o.OrderDetails)
				.FirstOrDefaultAsync(o => o.Id == order.Id);

			if (existingOrder == null)
			{
				throw new Exception("Order not found");
			}

			existingOrder.Amount = order.Amount;
			existingOrder.CreatedAt = order.CreatedAt;

			_context.Orders.Update(existingOrder);
			await _context.SaveChangesAsync();
		}
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
