using System;

namespace PointOfSale.Application.Features.SystemProducts.SystemProductCategory.Queries.GetProductCategoryList
{
    public class ProductCategoryVm
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
