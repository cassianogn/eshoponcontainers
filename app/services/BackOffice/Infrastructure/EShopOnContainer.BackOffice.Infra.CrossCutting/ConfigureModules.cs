using DTI.Core.Infra.Out.Observability.ELK;
using EShopOnContainer.BackOffice.Application;
using EShopOnContainer.BackOffice.Infra.Out.AccessData;
using EShopOnContainer.BackOffice.Infra.Out.Bus.Kafka;
using Microsoft.AspNetCore.Builder;
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
        public static Action<WebApplication> AddObservability(this WebApplicationBuilder builder)
        {
            return builder.AddObservabilityELK("back-office");
        }
    }
}
