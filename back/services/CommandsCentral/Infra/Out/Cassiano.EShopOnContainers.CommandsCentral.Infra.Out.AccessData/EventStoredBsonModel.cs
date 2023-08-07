using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.Out.AccessData
{
    internal class EventStoredBsonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid EventId { get; set; }
        public Guid? EntityId { get; set; }
        public string JsonCommand { get; set; }
        public string CommandTypeOf { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public bool Success { get; set; }
        public string FullException { get; set; }
        public string MessageException { get; set; }

    }

    internal static class EventStoredExtension
    {
        public static EventStored ToEventStored(this EventStoredBsonModel entity)
        {
            return new EventStored(entity.EventId,
                entity.EntityId,
                entity.JsonCommand,
                entity.CommandTypeOf,
                entity.Type,
                entity.Date, 
                entity.Success,
                entity.FullException,
                entity.MessageException);
        }

        public static EventStoredBsonModel ToEventStoredBsonModel(this EventStored model)
        {
            return new EventStoredBsonModel
            {
                EventId = model.Id,
                EntityId = model.EntityId,
                JsonCommand = model.JsonCommand,
                CommandTypeOf = model.CommandTypeOf,
                Type = model.Type,
                Date = model.Date,
                Success = model.Success,
                FullException = model.FullException,
                MessageException = model.MessageException
            };
        }
    }
}
