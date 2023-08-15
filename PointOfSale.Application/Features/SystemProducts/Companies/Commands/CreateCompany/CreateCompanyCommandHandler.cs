using AutoMapper;
using MediatR;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Application.Extensions;
using PointOfSale.Application.Responses;
using PointOfSale.Domain.Products;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await CreateCompanyCommandValidator.ValidateObjectAsync(request);
            validationResult.ThrowValidationExceptionOnFailure();
            var createCompanyCommandResponse = validationResult.ToResponse<CreateCompanyCommandResponse>();


            if (createCompanyCommandResponse.Success)
            {
                var company = _mapper.Map<Company>(request);
                company = await _companyRepository.AddOrUpdateAsync(company);
                createCompanyCommandResponse.Value = _mapper.Map<CreateCompanyDto>(company);
            }

            return createCompanyCommandResponse;
        }
    }
}
