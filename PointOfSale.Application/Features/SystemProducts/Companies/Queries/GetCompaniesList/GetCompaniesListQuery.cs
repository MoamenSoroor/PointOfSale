using MediatR;
using System.Collections.Generic;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList
{
    public class GetCompaniesListQuery : IRequest<List<CompaniesListVm>>
    {
    }
}
