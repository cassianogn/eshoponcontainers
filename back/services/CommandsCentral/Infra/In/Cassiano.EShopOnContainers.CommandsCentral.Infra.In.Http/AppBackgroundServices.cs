using Cassiano.EShopOnContainers.CommandsCentral.Application.In.SaveEventStored;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using MediatR;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.In.Http
{
    public class AppBackgroundServices : BackgroundService
    {
        private readonly IServiceProvider Services;
        public AppBackgroundServices(IServiceProvider services)
        {
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var providers = Services.CreateScope();
            var bus = providers.ServiceProvider.GetRequiredService<IInfrastructureBusService>();
            await bus.ConsumerAsync<SaveEventStoredCommand>(async command =>
            {
                using var actionProviders = Services.CreateScope();
                var mediator = actionProviders.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(command);
            }, stoppingToken
            );

        }
    }
}
