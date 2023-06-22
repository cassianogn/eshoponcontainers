using Cassiano.EShopOnContainers.Core.Domain;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cassiano.EShopOnContainers.Core.Application
{
    public static class CoreApplicationModule
    {
        // extension methods from IServiceCollection
        public static IServiceCollection AddCoreApplication<TInfrastructureBusService>(this IServiceCollection services, IList<Assembly> applicationAssemblies)
            where TInfrastructureBusService : class, IInfrastructureBusService
        {
            applicationAssemblies.Add(typeof(CoreApplicationModule).Assembly);
            services.AddCoreDomainModule<TInfrastructureBusService>(applicationAssemblies);
            return services;
        }
    }
}
