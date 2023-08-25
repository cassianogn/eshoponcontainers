using DTI.CommandsCentral.Domain.EventSourcing.DTOs;

namespace DTI.CommandsCentral.Domain.EventSourcing
{
    public interface IEventStoredRepository
    {
        Task AddAsync(EventStored entity, CancellationToken cancellationToken = default);
        public Task<IEnumerable<EventStored>> SeachAsync(SearchEventsStoredsDTO query);
        public Task<EventStored?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
