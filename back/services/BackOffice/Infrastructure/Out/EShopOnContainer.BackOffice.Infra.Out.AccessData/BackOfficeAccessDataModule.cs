using Microsoft.Extensions.DependencyInjection;
using EShopOnContainer.BackOffice.Application;
using EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products;
using Microsoft.EntityFrameworkCore;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData
{
    public static class BackOfficeAccessDataModule
    {
        public static IServiceCollection AddBackOfficeAccessData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BackOfficeDb>(options => options.UseSqlServer(connectionString));
            services.AddBackOfficeApplicationRepositories<ProductRepository, ColorRepository, CategoryRepository>();

            return services;
        }
    }
}
