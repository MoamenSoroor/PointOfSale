using PointOfSale.Domain.Common;

namespace PointOfSale.Domain.Products
{
    public class Company : AuditableEntity
    {
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyUrl { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }






}