using MediatR;
using PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList;
using System.Collections.Generic;

namespace PointOfSale.Application.Features.SystemProducts.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<CompaniesListVm>>
    {
    }
}
