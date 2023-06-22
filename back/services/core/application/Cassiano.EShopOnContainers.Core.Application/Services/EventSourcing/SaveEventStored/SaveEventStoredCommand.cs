using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.SaveEventStored
{
    public class SaveEventStoredCommand : IAppMessage, IRequest
    {

        public SaveEventStoredCommand(EventStored eventStored)
        {
            EventStored = eventStored;
        }

        public EventStored EventStored { get; private set; }
    }
}
