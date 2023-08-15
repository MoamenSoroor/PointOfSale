using AutoMapper;
using MediatR;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList;
using PointOfSale.Domain.Products;

namespace PointOfSale.Application.Features.SystemProducts.Products.Queries.GetProductList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetCompaniesListQuery, List<CompaniesListVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IMapper mapper, IProductRepository companyRepository)
        {
            _mapper = mapper;
            _productRepository = companyRepository;
        }

        public async Task<List<CompaniesListVm>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var allCompanies = (await _productRepository.ListAllAsync()).OrderBy(x => x.ProductName);
            return _mapper.Map<List<CompaniesListVm>>(allCompanies);
        }
    }
}
