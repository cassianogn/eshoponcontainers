using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using MediatR;

namespace Cassiano.EShopOnContainers.CommandsCentral.Application.In.Base
{
    public class BaseEventStoredDTO : EntityDTO
    {
        public Guid? EntityId { get; set; }
        public string JsonCommand { get; set; }
        public string CommandTypeOf { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public bool Success { get; set; }
        public string FullException { get; set; }
        public string MessageException { get; set; }
    }
}
