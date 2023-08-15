using System;

namespace PointOfSale.Application.Features.SystemProducts.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductUrl { get; set; }

    }
}
