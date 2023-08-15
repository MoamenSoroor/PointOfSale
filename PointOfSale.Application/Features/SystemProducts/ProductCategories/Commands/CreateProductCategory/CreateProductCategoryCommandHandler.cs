using AutoMapper;
using MediatR;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Application.Extensions;
using PointOfSale.Domain.Products;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Application.Features.SystemProducts.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, CreateProductCategoryCommandResponse>
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository ProductRepository)
        {
            _mapper = mapper;
            _categoryRepository = ProductRepository;
        }

        public async Task<CreateProductCategoryCommandResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await CreateProductCategoryCommandValidator.ValidateObjectAsync(request);
            validationResult.ThrowValidationExceptionOnFailure();

            var createProductCommandResponse = validationResult.ToResponse<CreateProductCategoryCommandResponse>();
            if (createProductCommandResponse.Success)
            {
                var product = _mapper.Map<ProductCategory>(request);
                product = await _categoryRepository.AddOrUpdateAsync(product);
                createProductCommandResponse.Value = _mapper.Map<CreateProductCategoryDto>(product);
            }

            return createProductCommandResponse;
        }
    }
}
