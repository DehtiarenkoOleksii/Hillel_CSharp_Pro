using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;
using InternetShop.Services.Exceptions;
using InternetShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services.Implementations
{
	public class OrderService : BaseService<Order, OrderDto>, IOrderService
	{
		private readonly IBaseRepository<Customer> _customerRepository;

		public OrderService(
			IBaseRepository<Order> orderRepo,
			IBaseRepository<Customer> customerRepo,
			IMapper mapper)
			: base(orderRepo, mapper)
		{
			_customerRepository = customerRepo;
		}

		public override async Task<OrderDto> CreateAsync(OrderDto dto)
		{
			var customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
			if (customer == null)
			{
				throw new Exception($"Customer with id {dto.CustomerId} not found");
			}

			return await base.CreateAsync(dto);
		}

		public override async Task<OrderDto?> UpdateAsync(int id, OrderDto dto)
		{
			var customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
			if (customer == null)
			{
				throw new Exception($"Customer with id {dto.CustomerId} not found");
			}

			return await base.UpdateAsync(id, dto);
		}
		public override async Task<bool> DeleteAsync(int id)
		{
			var order = await _repository
				.GetQueryable()
				.Include(o => o.OrderItems)
				.FirstOrDefaultAsync(o => o.Id == id);

			if (order == null)
			{
				throw new NotFoundException($"Order with id {id} not found.");
			}

			return await base.DeleteAsync(id);
		}

		public async Task<OrderDto?> GetByIdWithItemsAsync(int id)
		{
			var order = await _repository
				.GetQueryable()
				.Include(o => o.OrderItems)
				.FirstOrDefaultAsync(o => o.Id == id);

			return _mapper.Map<OrderDto>(order);
		}

		public async Task<List<OrderDto>> GetByCustomerIdAsync(int customerId)
		{
			var orders = await _repository
				.GetQueryable()
				.Include(o => o.OrderItems)
				.Where(o => o.CustomerId == customerId)
				.ToListAsync();

			return _mapper.Map<List<OrderDto>>(orders);
		}
	}
}

