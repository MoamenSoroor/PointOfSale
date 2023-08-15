using System;

namespace PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList
{
    public class CompaniesListVm
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyUrl { get; set; }
    }
}
