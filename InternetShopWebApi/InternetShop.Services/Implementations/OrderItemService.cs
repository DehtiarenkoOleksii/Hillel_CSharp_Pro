using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;
using InternetShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services.Implementations
{
	public class OrderItemService : BaseService<OrderItem, OrderItemDto>, IOrderItemService
	{
		private readonly IBaseRepository<Order> _orderRepository;
		private readonly IBaseRepository<Product> _productRepository;

		public OrderItemService(
			IBaseRepository<OrderItem> orderItemRepo,
			IBaseRepository<Order> orderRepo,
			IBaseRepository<Product> productRepo,
			IMapper mapper)
			: base(orderItemRepo, mapper)
		{
			_orderRepository = orderRepo;
			_productRepository = productRepo;
		}

		public override async Task<OrderItemDto> CreateAsync(OrderItemDto dto)
		{
			var order = await _orderRepository.GetByIdAsync(dto.OrderId);
			if (order == null)
			{
				throw new Exception($"Order with id {dto.OrderId} not found");
			}
			var product = await _productRepository.GetByIdAsync(dto.ProductId);
			if (product == null)
			{
				throw new Exception($"Product with id {dto.ProductId} not found");
			}

			return await base.CreateAsync(dto);
		}

		public override async Task<OrderItemDto?> UpdateAsync(int id, OrderItemDto dto)
		{
			var order = await _orderRepository.GetByIdAsync(dto.OrderId);
			if (order == null)
			{
				throw new Exception($"Order with id {dto.OrderId} not found");
			}

			var product = await _productRepository.GetByIdAsync(dto.ProductId);
			if (product == null)
			{
				throw new Exception($"Product with id {dto.ProductId} not found");
			}

			return await base.UpdateAsync(id, dto);
		}

		public async Task<List<OrderItemDto>> GetByOrderIdAsync(int orderId)
		{
			var orderItems = await _repository
				.GetQueryable()
				.Where(oi => oi.OrderId == orderId)
				.ToListAsync();

			return _mapper.Map<List<OrderItemDto>>(orderItems);
		}
	}
}
