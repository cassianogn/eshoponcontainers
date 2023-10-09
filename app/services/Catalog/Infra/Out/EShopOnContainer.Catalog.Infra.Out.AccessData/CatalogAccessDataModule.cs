using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using EShopOnContainer.Catalog.Application;
using EShopOnContainer.Catalog.Infra.Out.AccessData.Products;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.Out.AccessData
{
    public static class CatalogAccessDataModule
    {
        public static IServiceCollection AddCatalogAccessData(this IServiceCollection services, string connectionString)
        {
            var client = new ElasticsearchClient("<CLOUD_ID>", new ApiKey("<API_KEY>"));
            services.AddCatalogApplicationRepositories<ProductRepository>();

            return services;
        }
    }
}
