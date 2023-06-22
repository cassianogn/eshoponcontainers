using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Newtonsoft.Json;

namespace Cassiano.EShopOnContainers.Core.Domain.EventSourcing
{
    public class EventStored : IAppEvent
    {
        private EventStored(Guid id, Guid? entityId, string jsonCommand, string commandTypeOf, EventType type, bool success, string fullException, string messageException)
        {
            Id = id;
            JsonCommand = jsonCommand;
            CommandTypeOf = commandTypeOf;
            Date = DateTime.UtcNow;
            Type = type;
            Success = success;
            FullException = fullException;
            MessageException = messageException;
            EntityId = entityId;
        }

        public Guid Id { get; private set; }
        public Guid? EntityId { get; private set; }
        public string JsonCommand { get; private set; }
        public string CommandTypeOf { get; private set; }
        public DateTime Date { get; private set; }
        public EventType Type { get; private set; }
        public bool Success { get; private set; }
        public string FullException { get; private set; }
        public string MessageException { get; private set; }

        public static EventStored GetError(Guid? entityId, string jsonCommand, string commandTypeOf, EventType type, Exception exception)
        {
            string fullException;
            try
            {
                fullException = JsonConvert.SerializeObject(exception);
            }
            catch (Exception)
            {
                fullException = "";
            }
            return new EventStored( Guid.NewGuid(), entityId, jsonCommand, commandTypeOf, type, false, fullException, exception.Message);
        }

        public static EventStored GetSuccess(Guid entityId, string jsonCommand, string commandTypeOf, EventType type)
        {
           
            return new EventStored(Guid.NewGuid(), entityId, jsonCommand, commandTypeOf, type, true,"", "");
        }
    }
}
