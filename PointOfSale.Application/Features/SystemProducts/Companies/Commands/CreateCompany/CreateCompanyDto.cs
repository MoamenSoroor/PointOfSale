using System;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Commands.CreateCompany
{
    public class CreateCompanyDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyUrl { get; set; }

    }
}
