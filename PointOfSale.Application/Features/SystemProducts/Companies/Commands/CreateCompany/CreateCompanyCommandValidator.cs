using FluentValidation;
using FluentValidation.Results;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
    {
        public static Task<ValidationResult> ValidateObjectAsync(CreateCompanyCommand command)
        {
            return new CreateCompanyCommandValidator().ValidateAsync(command);
        }
        public CreateCompanyCommandValidator()
        {
            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.CompanyDescription)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");


        }
    }
}
