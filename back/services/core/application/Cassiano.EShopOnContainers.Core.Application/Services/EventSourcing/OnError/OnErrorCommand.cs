using Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.OnError
{
    public class OnErrorCommand : BaseEventStored, IRequest
    {
        public OnErrorCommand(object command, EventType commandType, Exception exception) : base(command, commandType)
        {
            Exception = exception;
        }


        public Exception Exception { get; private set; }
    }
}
