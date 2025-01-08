using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;
using InternetShop.Services.Exceptions;
using InternetShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services.Implementations
{
	public class ProductService : BaseService<Product, ProductDto>, IProductService
	{
		private readonly IBaseRepository<Category> _categoryRepository;
		private readonly IBaseRepository<OrderItem> _orderItemRepository;

		public ProductService(
			IBaseRepository<Product> productRepo,
			IBaseRepository<Category> categoryRepo,
			IBaseRepository<OrderItem> orderItemRepo,
			IMapper mapper)
			: base(productRepo, mapper)
		{
			_categoryRepository = categoryRepo;
			_orderItemRepository = orderItemRepo;
		}

		public override async Task<ProductDto> CreateAsync(ProductDto dto)
		{
			var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
			if (category == null)
			{
				throw new ValidationException($"Category with id {dto.CategoryId} not found");
			}

			return await base.CreateAsync(dto);
		}

		public override async Task<ProductDto?> UpdateAsync(int id, ProductDto dto)
		{
			var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
			if (category == null)
			{
				throw new ValidationException($"Category with id {dto.CategoryId} not found");
			}

			return await base.UpdateAsync(id, dto);
		}

		public async Task<List<ProductDto>> GetByCategoryAsync(int categoryId)
		{
			var all = await _repository.GetAllAsync();
			var filtered = all.Where(p => p.CategoryId == categoryId).ToList();
			return _mapper.Map<List<ProductDto>>(filtered);
		}

		public override async Task<bool> DeleteAsync(int id)
		{
			var product = await _repository.GetByIdAsync(id);
			if (product == null)
			{
				throw new NotFoundException($"Product with id {id} not found");
			}

			var hasOrderItems = await _orderItemRepository
				.GetQueryable()
				.AnyAsync(oi => oi.ProductId == id);

			if (hasOrderItems)
			{
				throw new ValidationException("Cannot delete product that is associated with existing orders");
			}

			return await base.DeleteAsync(id);
		}
	}
}
