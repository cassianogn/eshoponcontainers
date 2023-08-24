using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing;
using Microsoft.Extensions.DependencyInjection;
using Cassiano.EShopOnContainers.Core.Domain;

namespace Cassiano.EShopOnContainers.CommandsCentral.Application
{
    public static class CommandsCentralApplicationModule
    {
        public static IServiceCollection AddCommandsCentralApplicationCommands(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CommandsCentralApplicationModule).Assembly));
            return services;
        }
        public static IServiceCollection AddCommandsCentralApplicationRepositories<TEventStoredRepository>(this IServiceCollection services)
            where TEventStoredRepository : class, IEventStoredRepository

        {
            services.AddScoped<IEventStoredRepository, TEventStoredRepository>();
            return services;
        }
    }
}
