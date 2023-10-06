using EShopOnContainer.Catalog.Application;
using EShopOnContainer.Catalog.Infra.Out.AccessData.Products;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.Out.AccessData
{
    public static class CatalogAccessDataModule
    {
        public static IServiceCollection AddCatalogAccessData(this IServiceCollection services, string connectionString)
        {
            services.AddCatalogApplicationRepositories<ProductRepository>();

            return services;
        }
    }
}
