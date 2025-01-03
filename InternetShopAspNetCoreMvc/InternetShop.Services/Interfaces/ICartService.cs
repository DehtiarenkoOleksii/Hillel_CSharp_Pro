using InternetShop.Data.Models;


namespace InternetShop.Services.Interfaces
{
    public interface ICartService : IBaseService<CartItem>
    {
		Task<List<CartItem>> GetUserCartItemsAsync(int userId);
		Task AddToCartAsync(CartItem item);
		Task DeleteAllUserCartItemsAsync(int userId);
		Task<CartItem> GetCartItemAsync(int id);
		Task EditCartItemsAsync(CartItem item);
		Task DeleteUserCartItemAsync(CartItem item);
	}
}
