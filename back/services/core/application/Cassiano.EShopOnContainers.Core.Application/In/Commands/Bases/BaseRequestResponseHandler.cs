using Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.OnError;
using Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.OnSuccess;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases
{
    public abstract class BaseRequestResponseHandler<TRequest, TResponse> :
        IRequestHandler<TRequest, CommandResult<TResponse>>

        where TRequest : IRequest<CommandResult<TResponse>>, IEntityDTO
    {
        private readonly IMediator _mediator;

        protected BaseRequestResponseHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await ExecuteAsync(request, cancellationToken);
                await _mediator.Send(new OnSuccessCommand(request, GetEventType()), cancellationToken);
                return result;
            }
            catch (Exception error )
            {
                await _mediator.Send(new OnErrorCommand(request, GetEventType(), error), cancellationToken);
                throw;
            }
        }
        public abstract Task<CommandResult<TResponse>> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
        protected abstract EventType GetEventType();
    }
}
