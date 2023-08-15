using PointOfSale.Application.Contracts.Presistance;
using PointOfSale.Domain.Products;
using Moq;
using System;
using System.Collections.Generic;

namespace PointOfSale.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Product>> GetProductRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var products = new List<Product>
            {
                new Product
                {
                    Id = concertGuid,
                    ProductName = "Concerts"
                },
                new Product
                {
                    Id = musicalGuid,
                    ProductName = "Musicals"
                },
                new Product
                {
                    Id = conferenceGuid,
                    ProductName = "Conferences"
                },
                 new Product
                {
                    Id = playGuid,
                    ProductName = "Plays"
                }
            };

            var mockProductRepository = new Mock<IAsyncRepository<Product>>();
            mockProductRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(products);

            mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(
                (Product category) =>
                {
                    products.Add(category);
                    return category;
                });

            return mockProductRepository;
        }


        public static Mock<IAsyncRepository<ProductCategory>> GetProductCategoryRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    Id = concertGuid,
                    CategoryName = "Concerts"
                },
                new ProductCategory
                {
                    Id = musicalGuid,
                    CategoryName = "Musicals"
                },
                new ProductCategory
                {
                    Id = conferenceGuid,
                    CategoryName = "Conferences"
                },
                 new ProductCategory
                {
                    Id = playGuid,
                    CategoryName = "Plays"
                }
            };

            var mockProductCategoryRepository = new Mock<IAsyncRepository<ProductCategory>>();
            mockProductCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockProductCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<ProductCategory>())).ReturnsAsync(
                (ProductCategory category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockProductCategoryRepository;
        }


        public static Mock<IAsyncRepository<Company>> GetCompanyRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var companies = new List<Company>
            {
                new Company
                {
                    Id = concertGuid,
                    CompanyName = "Concerts"
                },
                new Company
                {
                    Id = musicalGuid,
                    CompanyName = "Musicals"
                },
                new Company
                {
                    Id = conferenceGuid,
                    CompanyName = "Conferences"
                },
                 new Company
                {
                    Id = playGuid,
                    CompanyName = "Plays"
                }
            };

            var mockCompanyRepository = new Mock<IAsyncRepository<Company>>();
            mockCompanyRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(companies);

            mockCompanyRepository.Setup(repo => repo.AddAsync(It.IsAny<Company>())).ReturnsAsync(
                (Company category) =>
                {
                    companies.Add(category);
                    return category;
                });

            return mockCompanyRepository;
        }

    }
}
