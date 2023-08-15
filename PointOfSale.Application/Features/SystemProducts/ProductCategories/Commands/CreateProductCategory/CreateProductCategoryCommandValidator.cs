using FluentValidation;
using FluentValidation.Results;

namespace PointOfSale.Application.Features.SystemProducts.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public static Task<ValidationResult> ValidateObjectAsync(CreateProductCategoryCommand command)
        {
            return new CreateProductCategoryCommandValidator().ValidateAsync(command);
        }
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");


            RuleFor(p => p.ProductDescription)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");


        }
    }
}
