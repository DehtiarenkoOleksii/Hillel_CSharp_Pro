using InternetShop.Data.Data;
using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Repositories.Repositories.Implementations
{
	public class CartRepository : BaseRepository<CartItem>, ICartRepository
	{
		public CartRepository(InternetShopDbContext context) : base(context)
		{
		}

		public async Task<List<CartItem>> GetUserCartItemsAsync(int userId)
		{
			return await _context.CartItems
				.Where(c => c.UserId == userId)
				.Include(c => c.Product) 
				.ToListAsync();
		}

		public async Task AddToCartAsync(CartItem item)
		{
			await _context.CartItems.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAllUserCartItemsAsync(int userId)
		{
			var items = _context.CartItems.Where(c => c.UserId == userId);
			_context.CartItems.RemoveRange(items);
			await _context.SaveChangesAsync();
		}

		public async Task<CartItem> GetCartItemAsync(int id)
		{
			return await _context.CartItems.FindAsync(id);
		}

		public async Task EditCartItemsAsync(CartItem item)
		{
			_context.CartItems.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteUserCartItemAsync(CartItem item)
		{
			_context.CartItems.Remove(item);
			await _context.SaveChangesAsync();
		}
	}
}
