using FluentValidation;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;

namespace InternetShop.Services.Validation
{
	public class OrderItemValidator : AbstractValidator<OrderItemDto>
	{
		public OrderItemValidator(IBaseRepository<Order> orderRepo,
								  IBaseRepository<Product> productRepo)
		{

			RuleFor(x => x.Quantity)
				.GreaterThan(0).WithMessage("Quantity must be > 0");

			RuleFor(x => x.UnitPrice)
				.GreaterThan(0).WithMessage("UnitPrice must be > 0");
		}
	}
}
