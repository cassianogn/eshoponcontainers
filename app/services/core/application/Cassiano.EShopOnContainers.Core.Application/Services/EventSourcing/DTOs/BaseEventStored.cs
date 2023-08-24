using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Newtonsoft.Json;

namespace Cassiano.EShopOnContainers.Core.Application.Services.EventSourcing.DTOs
{
    public abstract class BaseEventStored
    {
        protected BaseEventStored(object command, EventType commandType)
        {
            JsonCommand = JsonConvert.SerializeObject(command);
            CommandTypeOf = command!.GetType().FullName!;
            CommandType = commandType;

            var idProperty = command.GetType().GetProperty("Id");
            var hasIdProperty = idProperty != null;

            if (hasIdProperty)
                EntityId = idProperty?.GetValue(command) as Guid?;


        }
        public Guid? EntityId { get; private set; }
        public string JsonCommand { get; private set; }
        public string CommandTypeOf { get; private set; }
        public EventType CommandType { get; private set; }
    }
}
