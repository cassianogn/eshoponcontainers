using EShopOnContainer.BackOffice.Application;
using EShopOnContainer.BackOffice.Infra.Out.AccessData;
using EShopOnContainer.BackOffice.Infra.Out.Bus.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.BackOffice.Infra.CrossCutting
{
    public static class ConfigureModules
    {
        public static IServiceCollection AddApplicationWithDependencies(this IServiceCollection services, string connectionStringDb, string connectionStringBus)
        {
            services.AddBackOfficeApplicationBase(services => new BackOfficeKafkaBusService(connectionStringBus, "back-office-group"));
            services.AddBackOfficeAccessData(connectionStringDb);
            return services;
        }
    }
}
