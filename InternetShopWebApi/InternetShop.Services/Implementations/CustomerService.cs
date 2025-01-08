using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;
using InternetShop.Services.Exceptions;
using InternetShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace InternetShop.Services.Implementations
{
	public class CustomerService : BaseService<Customer, CustomerDto>, ICustomerService
	{
		public CustomerService(IBaseRepository<Customer> repository, IMapper mapper)
		: base(repository, mapper)
		{

		}
		public override async Task<bool> DeleteAsync(int id)
		{
			var customer = await _repository
				.GetQueryable()
				.Include(c => c.Orders)
				.FirstOrDefaultAsync(c => c.Id == id);

			if (customer == null)
			{
				throw new NotFoundException($"Customer with id {id} not found.");
			}

			return await base.DeleteAsync(id);
		}
	}
}
