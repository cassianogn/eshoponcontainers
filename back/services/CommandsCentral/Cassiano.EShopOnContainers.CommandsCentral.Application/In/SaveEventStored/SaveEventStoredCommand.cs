using Cassiano.EShopOnContainers.CommandsCentral.Application.In.Base;
using MediatR;

namespace Cassiano.EShopOnContainers.CommandsCentral.Application.In.SaveEventStored
{
    public class SaveEventStoredCommand : IRequest
    {
        public SaveEventStoredEvent EventStored { get; set; }
    }
}
