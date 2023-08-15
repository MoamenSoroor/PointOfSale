using MediatR;
using System.Collections.Generic;

namespace PointOfSale.Application.Features.SystemProducts.SystemProductCategory.Queries.GetProductCategoryList
{
    public class GetProductCategoryListQuery : IRequest<List<ProductCategoryVm>>
    {
    }
}
