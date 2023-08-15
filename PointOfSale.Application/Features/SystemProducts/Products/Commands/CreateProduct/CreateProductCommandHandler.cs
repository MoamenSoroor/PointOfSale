using AutoMapper;
using MediatR;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Application.Extensions;
using PointOfSale.Domain.Products;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Application.Features.SystemProducts.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await CreateProductCommandValidator.ValidateObjectAsync(request);
            validationResult.ThrowValidationExceptionOnFailure();
            var createProductCommandResponse = validationResult.ToResponse<CreateProductCommandResponse>();
            if (createProductCommandResponse.Success)
            {
                var product = _mapper.Map<Product>(request);
                product = await _productRepository.AddOrUpdateAsync(product);
                createProductCommandResponse.Value = _mapper.Map<CreateProductDto>(product);
            }

            return createProductCommandResponse;
        }
    }
}
