using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces
{
    public interface IInfrastructureBusService
    {
        Task PublishEvent<TData>(TData data, CancellationToken cancellationToken = default);
        Task<CommandResult> SendMessage<TData>(TData data, CancellationToken cancellationToken = default);
        Task<CommandResult<TResponse>> SendMessage<TData, TResponse>(TData data, CancellationToken cancellationToken = default);
        Task ConsumerAsync<TData>(Func<TData, Task> onConsume, CancellationToken cancellationToken = default);

    }
}
