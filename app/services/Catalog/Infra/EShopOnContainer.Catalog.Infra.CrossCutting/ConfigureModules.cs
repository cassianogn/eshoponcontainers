using EShopOnContainer.Catalog.Application;
using EShopOnContainer.Catalog.Infra.Out.AccessData;
using EShopOnContainer.Catalog.Infra.Out.Bus.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.CrossCutting
{
    public static class ConfigureModules
    {
        public static IServiceCollection AddApplicationWithDependencies(this IServiceCollection services, string connectionStringDb, string connectionStringBus)
        {
            services.AddCatalogApplicationApplicationBase(services => new CatalogKafkaBusService(connectionStringBus, "back-office-group"));
            services.AddCatalogAccessData(connectionStringDb);
            return services;
        }
    }
}
