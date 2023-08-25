using DTI.Core.Domain.EventSourcing;
using DTI.Core.Domain.Services.Bus.Interfaces;
using MediatR;

namespace DTI.Core.Application.Services.EventSourcing.SaveEventStored
{
    public class SaveEventStoredCommand : IAppMessage, IRequest
    {

        public SaveEventStoredCommand(EventStoredEvent eventStored)
        {
            EventStored = eventStored;
        }

        public EventStoredEvent EventStored { get; private set; }
    }
}
