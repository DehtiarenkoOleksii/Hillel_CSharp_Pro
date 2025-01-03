using InternetShop.Data.Models;

namespace InternetShop.Repositories.Repositories.Interfaces
{
    public interface ICartRepository : IBaseRepository<CartItem>
    {
		Task<List<CartItem>> GetUserCartItemsAsync(int userId);
		Task AddToCartAsync(CartItem item);
		Task DeleteAllUserCartItemsAsync(int userId);
		Task<CartItem> GetCartItemAsync(int id);
		Task EditCartItemsAsync(CartItem item);
		Task DeleteUserCartItemAsync(CartItem item);
	}
}
