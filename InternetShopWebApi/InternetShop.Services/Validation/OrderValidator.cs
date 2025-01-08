using FluentValidation;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;

namespace InternetShop.Services.Validation
{
	public class OrderValidator : AbstractValidator<OrderDto>
	{
		public OrderValidator(IBaseRepository<Customer> customerRepository)
		{

			RuleFor(x => x.Total)
				.GreaterThanOrEqualTo(0).WithMessage("Total can't be negative");

			RuleFor(x => x.OrderDate)
				.NotEmpty().WithMessage("OrderDate is required")
				.LessThanOrEqualTo(DateTime.Now).WithMessage("OrderDate can not be in the future");
		}
	}
}
