using AspNetCoreHero.ToastNotification.Abstractions;
using InternetShop.Data.Models;
using InternetShop.Services.Interfaces;
using InternetShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetShop.Web.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly INotyfService _notifyService;
		private const int UserId = 1;

		public ProductsController(
			IProductService productService,
			ICategoryService categoryService,
			IWebHostEnvironment webHostEnvironment,
			INotyfService notifyService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_webHostEnvironment = webHostEnvironment;
			_notifyService = notifyService;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productService.GetAllAsync();
			return View(products);
		}

		public async Task<IActionResult> Create()
		{
			ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateProductViewModel productVM)
		{
			if (ModelState.IsValid)
			{
				var newProduct = new Product
				{
					Name = productVM.Name,
					Description = productVM.Description,
					CreatedAt = DateTime.Now,
					Image = UploadedFile(productVM),
					Price = productVM.Price,
					CategoryId = productVM.CategoryId,
				};
				await _productService.AddAsync(newProduct);
				_notifyService.Success("Product created!");

				return RedirectToAction("Index");
			}

			ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", productVM.CategoryId);
			return View(productVM);
		}

		public async Task<IActionResult> Manage()
		{
			var products = await _productService.GetAllAsync();
			return View(products);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var product = await _productService.GetByIdAsync(id);

			if (product != null)
			{
				var editProductVM = EditProductViewModel.FromProduct(product);
				ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", product.CategoryId);

				return View(editProductVM);
			}

			_notifyService.Error("Product not found!");
			return RedirectToAction("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditProductViewModel productVM)
		{
			if (ModelState.IsValid)
			{
				var editedProduct = new Product
				{
					Id = productVM.Id,
					Name = productVM.Name,
					CategoryId = productVM.CategoryId,
					Description = productVM.Description,
					Price = productVM.Price,
					CreatedAt = productVM.CreatedAt,
				};

				if (productVM.Image == null)
				{
					editedProduct.Image = await _productService.GetImageNameAsync(productVM.Id);
				}
				else
				{
					var imageName = await _productService.GetImageNameAsync(productVM.Id);

					if (!imageName.Equals("no-image.jpg"))
					{
						System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "images", "Products", imageName));
					}

					editedProduct.Image = UploadedFile(productVM);
				}
				await _productService.UpdateAsync(editedProduct);
				_notifyService.Success("Product changed!");

				return RedirectToAction("Index");
			}

			ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", productVM.CategoryId);
			return View(productVM);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var product = await _productService.GetByIdAsync(id);

			if (product != null)
			{
				return View(product);
			}

			_notifyService.Error("Product not found!");
			return RedirectToAction("Index");
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				var product = await _productService.GetByIdAsync(id);

				if (product != null)
				{
					if (!product.Image.Equals("no-image.jpg"))
					{
						System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "images", "Products", product.Image));
					}

					await _productService.DeleteAsync(id);
					_notifyService.Success("Product deleted!");
				}
			}
			catch (Exception)
			{
				_notifyService.Error("Unable to delete product!");
			}

			return RedirectToAction(nameof(Index));
		}

		private string UploadedFile(IProductViewModelImage model)
		{
			string uniqueFileName = Path.Combine(_webHostEnvironment.WebRootPath, "images", "no-image.jpg");

			if (model.Image != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Products");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using var fileStream = new FileStream(filePath, FileMode.Create);
				model.Image.CopyTo(fileStream);
			}

			return uniqueFileName;
		}
	}
}
