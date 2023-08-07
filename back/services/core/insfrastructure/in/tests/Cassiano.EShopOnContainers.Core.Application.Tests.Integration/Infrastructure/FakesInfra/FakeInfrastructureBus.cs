using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.FakesInfra
{
    public class FakeInfrastructureBus : IInfrastructureBusService
    {
        private readonly DomainNotificationService _domainNotificationService;
        public FakeInfrastructureBus(DomainNotificationService domainNotificationService)
        {
            _domainNotificationService = domainNotificationService;
        }

        public Task ConsumerAsync<TData>(Func<TData, Task> onConsume, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task PublishEvent<TData>(TData data, CancellationToken cancellationToken = default)
        {
            _domainNotificationService.Add("testinfra", "Test");
            return Task.CompletedTask;
        }

        public Task<CommandResult> SendMessage<TData>(TData data, CancellationToken cancellationToken = default)
        {
            _domainNotificationService.Add("testinfra", "Test");
            return Task.FromResult(CommandResult.CommandFinished());
        }

        public Task<CommandResult<TResponse>> SendMessage<TData, TResponse>(TData data, CancellationToken cancellationToken = default)
        {
            _domainNotificationService.Add("testinfra", "Test");
#pragma warning disable CS8619 // A anulabilidade de tipos de referência no valor não corresponde ao tipo de destino.
            return Task.FromResult(CommandResult<TResponse>.CommandFinished(default));
#pragma warning restore CS8619 // A anulabilidade de tipos de referência no valor não corresponde ao tipo de destino.
        }

    }
}
