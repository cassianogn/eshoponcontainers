using EShopOnContainer.BackOffice.Application;
using EShopOnContainer.BackOffice.Infra.Out.AccessData;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.BackOffice.Infra.CrossCutting
{
    public static class ConfigureModules
    {
        public static IServiceCollection AddApplicationWithDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddBackOfficeApplicationBase<FakeBus>();
            services.AddBackOfficeAccessData(connectionString);
            return services;
        }
    }
}
