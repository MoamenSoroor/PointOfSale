using PointOfSale.Domain.Common;

namespace PointOfSale.Domain.Products
{
    public class ProductCategory : AuditableEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }






}