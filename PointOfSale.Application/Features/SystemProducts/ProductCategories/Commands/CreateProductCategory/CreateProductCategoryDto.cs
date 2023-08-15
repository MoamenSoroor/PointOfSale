using System;

namespace PointOfSale.Application.Features.SystemProducts.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}
