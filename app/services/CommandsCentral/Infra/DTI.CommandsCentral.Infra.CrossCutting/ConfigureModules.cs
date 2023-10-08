using DTI.CommandsCentral.Application;
using DTI.CommandsCentral.Infra.Out.AccessData;
using DTI.CommandsCentral.Infra.Out.Bus.Kafka;
using DTI.Core.Domain.Services.Bus.Interfaces;
using DTI.Core.Infra.Out.Observability.ELK;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DTI.CommandsCentral.Infra.CrossCutting
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

        public static Action<WebApplication> AddObservability(this WebApplicationBuilder builder)
        {
            return builder.AddObservabilityELK("commands-central");
        }
    }
}
