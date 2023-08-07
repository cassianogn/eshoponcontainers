using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.SaveEventStored
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
