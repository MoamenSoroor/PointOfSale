using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Domain.Products;

namespace PointOfSale.Presistance.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        { }

    }
}