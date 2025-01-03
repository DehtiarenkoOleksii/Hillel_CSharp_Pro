using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using InternetShop.Services.Interfaces;


namespace InternetShop.Services.Implementations
{
	public class CartService : BaseService<CartItem>, ICartService
	{
		private readonly ICartRepository _cartRepository;

		public CartService(ICartRepository cartRepository) : base(cartRepository)
		{
			_cartRepository = cartRepository;
		}

		public async Task<List<CartItem>> GetUserCartItemsAsync(int userId)
		{
			return await _cartRepository.GetUserCartItemsAsync(userId);
		}

		public async Task AddToCartAsync(CartItem item)
		{
			await _cartRepository.AddToCartAsync(item);
		}

		public async Task DeleteAllUserCartItemsAsync(int userId)
		{
			await _cartRepository.DeleteAllUserCartItemsAsync(userId);
		}

		public async Task<CartItem> GetCartItemAsync(int id)
		{
			return await _cartRepository.GetCartItemAsync(id);
		}

		public async Task EditCartItemsAsync(CartItem item)
		{
			await _cartRepository.EditCartItemsAsync(item);
		}

		public async Task DeleteUserCartItemAsync(CartItem item)
		{
			await _cartRepository.DeleteUserCartItemAsync(item);
		}
	}
}
