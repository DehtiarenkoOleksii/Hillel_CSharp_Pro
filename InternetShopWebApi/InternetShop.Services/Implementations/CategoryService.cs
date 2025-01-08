using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;
using InternetShop.Services.Implementations;
using InternetShop.Services.Interfaces;
using InternetShop.Services.Exceptions;


public class CategoryService : BaseService<Category, CategoryDto>, ICategoryService
{
	private readonly IBaseRepository<Product> _productRepo;

	public CategoryService(IBaseRepository<Category> categoryRepo,
						   IBaseRepository<Product> productRepo,
						   IMapper mapper)
		: base(categoryRepo, mapper)
	{
		_productRepo = productRepo;
	}

	public override async Task<bool> DeleteAsync(int id)
	{
		var category = await _repository.GetByIdAsync(id);
		if (category == null)
		{
			throw new NotFoundException($"Category with id {id} not found");
		}

		var products = await _productRepo.GetAllAsync();
		if (products.Any(p => p.CategoryId == id))
		{
			throw new ValidationException("Cannot delete category that has products");
		}

		return await base.DeleteAsync(id);
	}

}

