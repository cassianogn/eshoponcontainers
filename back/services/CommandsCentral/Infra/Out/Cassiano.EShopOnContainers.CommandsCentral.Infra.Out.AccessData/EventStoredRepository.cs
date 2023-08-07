using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Microsoft.Extensions.Options;
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

        public Task AddRangeAsync(IEnumerable<EventStored> entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<EventStored?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var bsonEvent = await _eventsCollection.Find(x => x.EventId == id).FirstOrDefaultAsync(cancellationToken);
            return bsonEvent?.ToEventStored();
        }

        public Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey = "", CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EventStored entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}