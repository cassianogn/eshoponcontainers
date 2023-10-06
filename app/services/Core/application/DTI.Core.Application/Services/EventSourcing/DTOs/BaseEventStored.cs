using DTI.Core.Domain.EventSourcing;
using Newtonsoft.Json;

namespace DTI.Core.Application.Services.EventSourcing.DTOs
{
    public abstract class BaseEventStored
    {
        protected BaseEventStored(object command, EventType commandType)
        {
            JsonCommand = JsonConvert.SerializeObject(command);
            CommandTypeOf = command!.GetType().FullName!;
            CommandType = commandType;

            var propertyId = command.GetType().GetProperty("Id");
            var hasIdProperty = propertyId != null;

            if (hasIdProperty)
                EntityId = propertyId?.GetValue(command) as Guid?;


        }
        public Guid? EntityId { get; private set; }
        public string JsonCommand { get; private set; }
        public string CommandTypeOf { get; private set; }
        public EventType CommandType { get; private set; }
    }
}
