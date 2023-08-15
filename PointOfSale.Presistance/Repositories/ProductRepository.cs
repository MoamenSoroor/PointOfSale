using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Domain.Products;

namespace PointOfSale.Presistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PointOfSaleDbContext dbContext) 
            : base(dbContext)
        { }


    }

}