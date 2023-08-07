using Cassiano.EShopOnContainers.CommandsCentral.Application;
using Cassiano.EShopOnContainers.CommandsCentral.Infra.Out.AccessData;
using Cassiano.EShopOnContainers.CommandsCentral.Infra.Out.Bus.Kafka;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.CrossCutting
{
    public static class ConfigureModules
    {
        public static IServiceCollection AddApplicationWithDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCommandsCentralApplicationCommands();
            services.AddCommandsCentralMongoAccessData(configuration);
            services.AddScoped<IInfrastructureBusService>(provider =>
            {
                var service = new CommandsCentralKafkaBusService(configuration.GetSection("BusServiceConnection:Kafka").Value!, "CommandsCentral"); ;
                return service;
            });
            return services;
        }
    }
}
