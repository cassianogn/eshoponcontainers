using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;

namespace EShopOnContainer.BackOffice.Infra.CrossCutting
{
    internal class FakeBus : IInfrastructureBusService
    {
        public Task PublishEvent<TData>(TData data, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<CommandResult> SendMessage<TData>(TData data, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(CommandResult.CommandFinished());
        }

        public Task<CommandResult<TResponse>> SendMessage<TData, TResponse>(TData data, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS8619 // A anulabilidade de tipos de referência no valor não corresponde ao tipo de destino.
            return Task.FromResult(CommandResult<TResponse>.CommandFinished(default));
#pragma warning restore CS8619 // A anulabilidade de tipos de referência no valor não corresponde ao tipo de destino.

        }
    }
}
