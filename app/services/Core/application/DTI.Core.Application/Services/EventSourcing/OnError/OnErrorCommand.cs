using DTI.Core.Application.Services.EventSourcing.DTOs;
using DTI.Core.Domain.EventSourcing;
using MediatR;

namespace DTI.Core.Application.Services.EventSourcing.OnError
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
