using FluentValidation;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;
using InternetShop.Repositories.Interfaces;


namespace InternetShop.Services.Validation
{
	public class ProductValidator : AbstractValidator<ProductDto>
	{
		public ProductValidator(IBaseRepository<Category> categoryRepository)
		{

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Product name is required")
				.MaximumLength(100).WithMessage("Name can not exceed 100 chars");

			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("Description is required")
				.MaximumLength(200);

			RuleFor(x => x.Price)
				.GreaterThan(0).WithMessage("Price must be > 0");

		}
	}
}
