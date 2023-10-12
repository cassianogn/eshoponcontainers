using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using EShopOnContainer.Catalog.Application;
using EShopOnContainer.Catalog.Infra.Out.AccessData.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.Out.AccessData
{
    public static class CatalogAccessDataModule
    {
        public static IServiceCollection AddCatalogAccessData(this IServiceCollection services, string elasticCloudId, string elasticCloudApiKey)
        {
            AddElasticsearch(services, elasticCloudId, elasticCloudApiKey);
            services.AddCatalogApplicationRepositories<ProductRepository>();

            return services;
        }

        private static void AddElasticsearch(IServiceCollection services, string elasticCloudId, string elasticApiKey)
        {
            var client = new ElasticsearchClient(elasticCloudId, new ApiKey(elasticApiKey));
            services.AddSingleton(client);
        }
    }
}
