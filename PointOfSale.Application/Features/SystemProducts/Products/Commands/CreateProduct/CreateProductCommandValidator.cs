using FluentValidation;
using FluentValidation.Results;

namespace PointOfSale.Application.Features.SystemProducts.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public static Task<ValidationResult> ValidateObjectAsync(CreateProductCommand command)
        {
            return new CreateProductCommandValidator().ValidateAsync(command);
        }

        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.ProductDescription)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");


        }
    }
}
