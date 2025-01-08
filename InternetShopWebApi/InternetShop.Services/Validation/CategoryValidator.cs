using FluentValidation;
using InternetShop.Contract.DTO;

namespace InternetShop.Services.Validation
{
	public class CategoryValidator : AbstractValidator<CategoryDto>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Category name is required")
				.MaximumLength(100);
		}
	}
}
