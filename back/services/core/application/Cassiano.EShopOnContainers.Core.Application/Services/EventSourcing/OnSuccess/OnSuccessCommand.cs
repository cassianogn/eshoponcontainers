using Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.OnSuccess
{
    public class OnSuccessCommand : BaseEventStored, IRequest
    {
        public OnSuccessCommand(object command, EventType commandType) : base(command, commandType)
        {
        }
    }

}
