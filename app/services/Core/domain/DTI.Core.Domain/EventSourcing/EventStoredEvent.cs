using DTI.Core.Domain.Services.Bus.Interfaces;
using Newtonsoft.Json;

namespace DTI.Core.Domain.EventSourcing
{
    public class EventStoredEvent : IAppEvent
    {
        private EventStoredEvent(Guid id, Guid? entityId, string jsonCommand, string commandTypeOf, EventType type, bool success, string fullException, string messageException)
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

        public static EventStoredEvent GetError(Guid? entityId, string jsonCommand, string commandTypeOf, EventType type, Exception exception)
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
            return new EventStoredEvent( Guid.NewGuid(), entityId, jsonCommand, commandTypeOf, type, false, fullException, exception.Message);
        }

        public static EventStoredEvent GetSuccess(Guid entityId, string jsonCommand, string commandTypeOf, EventType type)
        {
           
            return new EventStoredEvent(Guid.NewGuid(), entityId, jsonCommand, commandTypeOf, type, true,"", "");
        }
    }
}
