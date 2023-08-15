using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Domain.Products;

namespace PointOfSale.Presistance.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        { }


    }

}