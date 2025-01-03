using AspNetCoreHero.ToastNotification.Abstractions;
using InternetShop.Data.Models;
using InternetShop.Services.Interfaces;
using InternetShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Web.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly INotyfService _notifyService;

		public CategoriesController(ICategoryService categoryService, INotyfService notifyService)
		{
			_categoryService = categoryService;
			_notifyService = notifyService;
		}

		public async Task<IActionResult> Index()
		{
			try
			{
				var categories = await _categoryService.GetAllAsync();
				return View(categories);
			}
			catch (Exception)
			{
				_notifyService.Error("An error occurred!");
				return RedirectToAction("Index", "Products");
			}
		}

		public async Task<IActionResult> Manage()
		{
			try
			{
				var categories = await _categoryService.GetAllAsync();
				return View(categories);
			}
			catch (Exception)
			{
				_notifyService.Error("An error occurred!");
				return RedirectToAction("Index", "Products");
			}
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CategoryViewModel categoryVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var category = new Category
					{
						Name = categoryVM.Name,
						Description = categoryVM.Description,
						CreatedAt = DateTime.Now,
					};
					await _categoryService.AddAsync(category);
					_notifyService.Success("Created category!");

					return RedirectToAction("Index");
				}

				return View(categoryVM);
			}
			catch (Exception)
			{
				_notifyService.Error("An error occurred!");
				return RedirectToAction("Index");
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			var category = await _categoryService.GetByIdAsync(id);
			return View(category);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Category category)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _categoryService.UpdateAsync(category);
					_notifyService.Success("Changed category!");
				}

				return View(category);
			}
			catch (Exception)
			{
				_notifyService.Error("An error occurred!");
				return RedirectToAction("Index");
			}
		}

		public async Task<IActionResult> Delete(int? id)
		{
			var category = await _categoryService.GetByIdAsync(id.Value);

			if (category != null)
			{
				return View(category);
			}

			return RedirectToAction("Index");
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await _categoryService.DeleteAsync(id);
				_notifyService.Success("Deleted category!");

				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				_notifyService.Error("An error occurred!");
				return RedirectToAction("Index");
			}
		}

		public async Task<IActionResult> CategoryProducts(int id)
		{
			var category = await _categoryService.GetCategoryWithProductsAsync(id);

			if (category == null || category.Products == null || !category.Products.Any())
			{
				_notifyService.Error("No products found in this category");
				return RedirectToAction("Index");
			}

			return View(category);
		}
	}
}