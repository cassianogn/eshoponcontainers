﻿using DTI.CommandsCentral.Domain.EventSourcing;
using DTI.Core.Domain.EventSourcing;
using MediatR;

namespace DTI.CommandsCentral.Application.In.SaveEventStored
{
    internal class SaveEventStoredCommandHandler : IRequestHandler<SaveEventStoredCommand>
    {
        private readonly IEventStoredRepository _eventStoredRepository;

        public SaveEventStoredCommandHandler(IEventStoredRepository eventStoredRepository)
        {
            _eventStoredRepository = eventStoredRepository;
        }
        public async Task Handle(SaveEventStoredCommand request, CancellationToken cancellationToken)
        {
            var eventStored = new EventStored(request.EventStored.Id, request.EventStored.EntityId, request.EventStored.JsonCommand, request.EventStored.CommandTypeOf, request.EventStored.Type, request.EventStored.Date, request.EventStored.Success, request.EventStored.FullException, request.EventStored.MessageException);
            await _eventStoredRepository.AddAsync(eventStored);
        }
    }
}
