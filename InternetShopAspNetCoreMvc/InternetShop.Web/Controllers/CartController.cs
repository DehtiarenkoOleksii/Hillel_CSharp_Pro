using AspNetCoreHero.ToastNotification.Abstractions;
using InternetShop.Data.Models;
using InternetShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Web.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartService _cartService;
		private readonly INotyfService _notifyService;
		private const int UserId = 1;

		public CartController(ICartService cartService, INotyfService notifyService)
		{
			_cartService = cartService;
			_notifyService = notifyService;
		}

		public async Task<IActionResult> Index()
		{
			var cartItems = await _cartService.GetUserCartItemsAsync(UserId);
			return View(cartItems);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(CartItem item)
		{
			item.UserId = UserId;
			await _cartService.AddToCartAsync(item);
			_notifyService.Success("Added to cart!");

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> EmptyCart()
		{
			await _cartService.DeleteAllUserCartItemsAsync(UserId);
			_notifyService.Success("Removed all from cart!");

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var cartItem = await _cartService.GetCartItemAsync(id);

			if (cartItem != null)
			{
				return View(cartItem);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Edit(CartItem item)
		{
			await _cartService.EditCartItemsAsync(item);
			_notifyService.Success("Changed successfully!");

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var cartItem = await _cartService.GetCartItemAsync(id);

			if (cartItem != null)
			{
				await _cartService.DeleteUserCartItemAsync(cartItem);
				_notifyService.Success("Deleted successfully!");
			}

			return RedirectToAction("Index");
		}
	}
}