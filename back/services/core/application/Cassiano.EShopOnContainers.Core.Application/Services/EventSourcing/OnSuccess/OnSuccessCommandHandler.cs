using Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.SaveEventStored;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.OnSuccess
{
    internal class OnSuccessCommandHandler : IRequestHandler<OnSuccessCommand>
    {
        private readonly IMediator _mediator;

        public OnSuccessCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OnSuccessCommand request, CancellationToken cancellationToken)
        {
            if (!request.EntityId.HasValue)
                throw new Exception($"The command run with success hasn't a \"Id\" seted. the command: {request.CommandTypeOf}");

            var eventStored = EventStoredEvent.GetSuccess(request.EntityId.Value, request.JsonCommand, request.CommandTypeOf!, request.CommandType);
            var command = new SaveEventStoredCommand(eventStored);
            await _mediator.Send(command, cancellationToken);
        }
    }
}
