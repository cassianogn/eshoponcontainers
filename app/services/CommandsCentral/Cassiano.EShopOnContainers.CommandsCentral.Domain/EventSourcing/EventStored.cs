using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;

namespace Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing
{
    public class EventStored : Entity<EventStored>
    {
        public EventStored(Guid id, Guid? entityId, string jsonCommand, string commandTypeOf, EventType type, DateTime date, bool success, string fullException, string messageException) : base(id)
        {
            JsonCommand = jsonCommand;
            CommandTypeOf = commandTypeOf;
            Date = date;
            Type = type;
            Success = success;
            FullException = fullException;
            MessageException = messageException;
            EntityId = entityId;
        }

        public Guid? EntityId { get; private set; }
        public string JsonCommand { get; private set; }
        public string CommandTypeOf { get; private set; }
        public DateTime Date { get; private set; }
        public EventType Type { get; private set; }
        public bool Success { get; private set; }
        public string FullException { get; private set; }
        public string MessageException { get; private set; }

    }
}
