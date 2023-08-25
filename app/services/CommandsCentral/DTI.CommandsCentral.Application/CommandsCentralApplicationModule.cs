using DTI.CommandsCentral.Domain.EventSourcing;
using Microsoft.Extensions.DependencyInjection;
using DTI.Core.Domain;

namespace DTI.CommandsCentral.Application
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
