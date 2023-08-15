using MediatR;

namespace PointOfSale.Application.Features.SystemProducts.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<CreateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductUrl { get; set; }

    }

}
