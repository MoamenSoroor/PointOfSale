using AutoMapper;
using MediatR;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList
{
    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery, List<CompaniesListVm>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesListQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<List<CompaniesListVm>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var allCompanies = (await _companyRepository.ListAllAsync()).OrderBy(x => x.CompanyName);
            return _mapper.Map<List<CompaniesListVm>>(allCompanies);
        }
    }
}
