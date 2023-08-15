using MediatR;

namespace PointOfSale.Application.Features.SystemProducts.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<CreateProductCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductUrl { get; set; }

    }

}
