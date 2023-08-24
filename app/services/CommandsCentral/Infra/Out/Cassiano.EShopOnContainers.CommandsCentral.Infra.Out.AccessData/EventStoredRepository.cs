﻿using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing;
using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing.DTOs;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.Out.AccessData
{
    public class EventStoredRepository : IEventStoredRepository
    {
        private readonly IMongoCollection<EventStoredBsonModel> _eventsCollection;

        public EventStoredRepository(IOptions<MongoDatabaseSettings> mongoOptionsService)
        {
            var mongoClient = new MongoClient(mongoOptionsService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoOptionsService.Value.DatabaseName);
            _eventsCollection = mongoDatabase.GetCollection<EventStoredBsonModel>(mongoOptionsService.Value.EventStoredCollection);
        }

        public async Task AddAsync(EventStored entity, CancellationToken cancellationToken = default)
        {
            var bsonEvent = entity.ToEventStoredBsonModel();
            await _eventsCollection.InsertOneAsync(bsonEvent, cancellationToken: cancellationToken);
        }


        public async Task<EventStored?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var bsonEvent = await _eventsCollection.Find(x => x.EventId == id).FirstOrDefaultAsync(cancellationToken);
            return bsonEvent?.ToEventStored();
        }

        public async Task<IEnumerable<EventStored>> SeachAsync(SearchEventsStoredsDTO query)
        {
            var filter = Builders<EventStoredBsonModel>.Filter.Empty;

            if (query.StartDate.HasValue)
                filter &= Builders<EventStoredBsonModel>.Filter.Gte(x => x.Date, query.StartDate.Value);

            if (query.EndDate.HasValue)
                filter &= Builders<EventStoredBsonModel>.Filter.Lte(x => x.Date, query.EndDate.Value);

            if (query.Success.HasValue)
                filter &= Builders<EventStoredBsonModel>.Filter.Eq(x => x.Success, query.Success);

            if (!string.IsNullOrEmpty(query.CommandType))
                filter &= Builders<EventStoredBsonModel>.Filter.Eq(x => x.CommandTypeOf, query.CommandType);

            if (query.EntityId.HasValue)
                filter &= Builders<EventStoredBsonModel>.Filter.Eq(x => x.EntityId, query.EntityId);

            if (!string.IsNullOrEmpty(query.Body))
                filter &= Builders<EventStoredBsonModel>.Filter.Regex(x => x.JsonCommand, new BsonRegularExpression(query.Body, "i"));
            
            if (!string.IsNullOrEmpty(query.CommandType))
                filter &= Builders<EventStoredBsonModel>.Filter.Regex(x => x.CommandTypeOf, new BsonRegularExpression(query.CommandType, "i"));


            var result = (await _eventsCollection.Find(filter).Limit(query.LimitOfResult).ToListAsync()).Select(eventStoredBson => eventStoredBson.ToEventStored());
            return result;
        }
    }
}