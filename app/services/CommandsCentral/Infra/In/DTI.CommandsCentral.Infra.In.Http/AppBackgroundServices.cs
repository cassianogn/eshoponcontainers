using DTI.CommandsCentral.Application.In.SaveEventStored;
using DTI.Core.Domain.Services.Bus.Interfaces;
using MediatR;

namespace DTI.CommandsCentral.Infra.In.Http
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
