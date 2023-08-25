using DTI.Core.Application.Services.EventSourcing.DTOs;
using DTI.Core.Domain.EventSourcing;
using MediatR;

namespace DTI.Core.Application.Services.EventSourcing.OnSuccess
{
    public class OnSuccessCommand : BaseEventStored, IRequest
    {
        public OnSuccessCommand(object command, EventType commandType) : base(command, commandType)
        {
        }
    }

}
