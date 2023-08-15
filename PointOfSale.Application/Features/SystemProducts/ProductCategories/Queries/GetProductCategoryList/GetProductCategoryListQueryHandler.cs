using AutoMapper;
using MediatR;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace PointOfSale.Application.Features.SystemProducts.SystemProductCategory.Queries.GetProductCategoryList
{
    public class GetProductCategoryListQueryHandler : IRequestHandler<GetProductCategoryListQuery, List<ProductCategoryVm>>
    {
        private readonly IProductCategoryRepository _categoryCompany;
        private readonly IMapper _mapper;

        public GetProductCategoryListQueryHandler(IMapper mapper, IProductCategoryRepository companyRepository)
        {
            _mapper = mapper;
            _categoryCompany = companyRepository;
        }

        public async Task<List<ProductCategoryVm>> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryCompany.ListAllAsync()).OrderBy(x => x.CategoryName);
            return _mapper.Map<List<ProductCategoryVm>>(allCategories);
        }
    }
}
