using AspNetCoreHero.ToastNotification.Abstractions;
using InternetShop.Data.Models;
using InternetShop.Services.Interfaces;
using InternetShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetShop.Web.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly ICartService _cartService;
		private readonly ILogger<OrdersController> _logger;
		private readonly INotyfService _notifyService;
		private const int UserId = 1;

		public OrdersController(
			IOrderService orderService,
			ICartService cartService,
			ILogger<OrdersController> logger,
			INotyfService notifyService)
		{
			_orderService = orderService;
			_cartService = cartService;
			_notifyService = notifyService;
			_logger = logger;
		}

		public async Task<IActionResult> Manage()
		{
			var orders = await _orderService.GetAllOrdersWithDetailsAsync();
			return View(orders);
		}

		public async Task<IActionResult> Index()
		{
			var orders = await _orderService.GetUserOrdersWithDetailsAsync(UserId);

			if (orders == null || !orders.Any())
			{
				_logger.LogWarning("No orders found for UserId {UserId}", UserId);
			}

			return View(orders);
		}

		public async Task<IActionResult> Details(int id)
		{
			var order = await _orderService.GetOrderWithDetailsAsync(id);

			if (order != null)
			{
				return View(order);
			}

			return View("DoesNotExist");
		}

		[HttpGet]
		public async Task<IActionResult> PlaceOrder()
		{
			var orderItems = await _cartService.GetUserCartItemsAsync(UserId);
			ViewData["total"] = orderItems.Select(c => c.Product.Price * c.Quantity).Sum() + 10;

			return View(orderItems);
		}

		public async Task<IActionResult> PlaceOrderConfirmed()
		{
			await _orderService.ConfirmOrderAsync(UserId);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var order = await _orderService.GetOrderWithDetailsAsync(id);
			if (order != null)
			{
				return View(order);
			}
			_notifyService.Error("Product not found!");

			return RedirectToAction("Index");
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _orderService.DeleteOrderAsync(id);
			_notifyService.Success("Order deleted successfully!");
			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _orderService.GetOrderWithDetailsAsync(id);

            if (order == null)
            {
                _notifyService.Error("Order not found!");
                return RedirectToAction("Manage");
            }

            var orderVM = new EditOrderViewModel
            {
                Id = order.Id,
                UserId = order.UserId,
                Amount = order.Amount,
                CreatedAt = order.CreatedAt
            };

            ViewData["UserId"] = new SelectList(await _orderService.GetAllUsersAsync(), "Id", "Fullname", order.UserId);
            return View(orderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditOrderViewModel orderVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["UserId"] = new SelectList(await _orderService.GetAllUsersAsync(), "Id", "Fullname", orderVM.UserId);
                return View(orderVM);
            }

            var editedOrder = new Order
            {
                Id = orderVM.Id,
                UserId = orderVM.UserId,
                Amount = orderVM.Amount,
                CreatedAt = orderVM.CreatedAt
            };

            try
            {
                await _orderService.UpdateOrderAsync(editedOrder);
                _notifyService.Success("Order updated successfully!");
                return RedirectToAction("Manage");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update order with ID {Id}", orderVM.Id);
                _notifyService.Error("Failed to update the order.");
                return View(orderVM);
            }
        }
    }
}
