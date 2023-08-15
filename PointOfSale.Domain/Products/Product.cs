using PointOfSale.Domain.Common;
using PointOfSale.Domain.Files;

namespace PointOfSale.Domain.Products
{

    public class Product : AuditableEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBarCode { get; set; }
        public virtual ICollection<ApplicationFile> ProductFiles { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = new Company();


    }






}