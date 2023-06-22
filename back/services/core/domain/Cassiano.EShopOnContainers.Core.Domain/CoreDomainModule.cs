using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cassiano.EShopOnContainers.Core.Domain
{
    public static class CoreDomainModule
    {
        public static IServiceCollection AddCoreDomainModule<TInfrastructureBusService>(this IServiceCollection services, IList<Assembly> applicationAssemblies)
            where TInfrastructureBusService : class, IInfrastructureBusService
        {
            services.AddMediatR(cfg => {
                foreach (var assembly in applicationAssemblies)
                    cfg.RegisterServicesFromAssembly(assembly);
                
                cfg.RegisterServicesFromAssembly(typeof(CoreDomainModule).Assembly);
            });

            services.AddScoped<DomainNotificationService>();
            services.AddScoped<IInfrastructureBusService, TInfrastructureBusService>();
            services.AddScoped<BusService>();

            return services;
        }
    }
}
