using MediatR;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand: IRequest<CreateCompanyCommandResponse>
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyUrl { get; set; }

    }
}
