using FluentValidation;
using InternetShop.Contract.DTO;

namespace InternetShop.Services.Validation
{
	public class CustomerValidator : AbstractValidator<CustomerDto>
	{
		public CustomerValidator()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty().WithMessage("FirstName is required")
				.MaximumLength(100);

			RuleFor(x => x.LastName)
				.NotEmpty().WithMessage("LastName is required")
				.MaximumLength(100);

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required")
				.EmailAddress().WithMessage("Invalid Email format")
				.MaximumLength(100);

			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Phone is required")
				.MaximumLength(14).WithMessage("Phone cannot exceed 14 digits");
		}
	}
}
