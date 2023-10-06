using DTI.Core.Domain.Services.Bus.Interfaces;
using DTI.Core.Domain.Services.Bus.Models;
using MediatR;

namespace DTI.Core.Domain.Services.Bus
{
    public class BusService
    {
        private readonly IMediator _mediator;
        private readonly IInfrastructureBusService _infrastructureBus;

        public BusService(IMediator mediator, IInfrastructureBusService infrastructureBus)
        {
            _mediator = mediator;
            _infrastructureBus = infrastructureBus;
        }

        public async Task PublishEvent<TData>(TData data, BusTransactionType transactionType = BusTransactionType.Memory, CancellationToken cancellationToken = default)
            where TData : IAppEvent
        {
            switch (transactionType)
            {
                case BusTransactionType.Memory:
                    await _mediator.Publish(data!, cancellationToken);
                    break;
                case BusTransactionType.Infrastructure:
                    await _infrastructureBus.PublishEvent(data, cancellationToken);
                    break;
                default:
                    throw new Exception("Invalid transaction type");
            }

        }

        public async Task<CommandResult> SendMessage<TData>(TData data, BusTransactionType transactionType = BusTransactionType.Memory, CancellationToken cancellationToken = default)
            where TData : IAppMessage
        {
            return transactionType switch
            {
                BusTransactionType.Memory => await _mediator.Send(data!, cancellationToken),
                BusTransactionType.Infrastructure => await _infrastructureBus.SendMessage(data, cancellationToken),
                _ => throw new Exception("Invalid transaction type"),
            };
        }
        public async Task<CommandResult<TResponse>> SendMessage<TData, TResponse>(TData data, BusTransactionType transactionType = BusTransactionType.Memory, CancellationToken cancellationToken = default)
            where TData : IAppMessage<TResponse>
        {
            switch (transactionType)
            {
                case BusTransactionType.Memory:
                    return await _mediator.Send(data!, cancellationToken);
                case BusTransactionType.Infrastructure:
                    return await _infrastructureBus.SendMessage<TData, TResponse>(data, cancellationToken);
                default:
                    throw new Exception("Invalid transaction type");
            }

        }
    }
}
