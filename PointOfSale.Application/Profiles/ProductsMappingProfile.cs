using AutoMapper;
using PointOfSale.Application.Features.SystemProducts.Commands.CreateProduct;
using PointOfSale.Application.Features.SystemProducts.Companies.Commands.CreateCompany;
using PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList;
using PointOfSale.Application.Features.SystemProducts.Products.Queries.GetProductList;
using PointOfSale.Domain.Products;
using PointOfSale.Application.Features.SystemProducts.SystemProductCategory.Queries.GetProductCategoryList;
using PointOfSale.Application.Features.SystemProducts.ProductCategories.Commands.CreateProductCategory;

namespace PointOfSale.Application.Profiles
{
    public class ProductsMappingProfile: Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, CompaniesListVm>();


            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, ProductListVm>();

            CreateMap<ProductCategory, CreateProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryVm>();



            //CreateMap<Event, CreateEventCommand>().ReverseMap();
            //CreateMap<Event, UpdateEventCommand>().ReverseMap();
            //CreateMap<Event, EventDetailVm>().ReverseMap();
            //CreateMap<Event, CategoryEventDto>().ReverseMap();
            //CreateMap<Event, EventExportDto>().ReverseMap();

            //CreateMap<Category, CategoryDto>();
            //CreateMap<Category, CategoryListVm>();
            //CreateMap<Category, CategoryEventListVm>();
            //CreateMap<Category, CreateCategoryCommand>();
            //CreateMap<Category, CreateCategoryDto>();

            //CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
