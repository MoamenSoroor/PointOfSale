using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Application.Contracts.Presistance.Products;
using PointOfSale.Presistance.Repositories;

namespace PointOfSale.Presistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PointOfSaleDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PointOfSaleDbContextConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();


            return services;
        }
    }
}