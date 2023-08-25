using DTI.Core.Application.Services.EventSourcing.SaveEventStored;
using DTI.Core.Domain.EventSourcing;
using MediatR;

namespace DTI.Core.Application.Services.EventSourcing.OnError
{
    internal class OnErrorCommandHandler : IRequestHandler<OnErrorCommand>
    {
        private readonly IMediator _mediator;

        public OnErrorCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OnErrorCommand request, CancellationToken cancellationToken)
        {
            var eventStored = EventStoredEvent.GetError(request.EntityId, request.JsonCommand, request.CommandTypeOf!, request.CommandType, request.Exception);
            var command = new SaveEventStoredCommand(eventStored);
            await _mediator.Send(command, cancellationToken);
        }
    }
}
