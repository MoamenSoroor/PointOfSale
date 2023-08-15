using System;

namespace PointOfSale.Application.Features.SystemProducts.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBarCode { get; set; }
    }
}
