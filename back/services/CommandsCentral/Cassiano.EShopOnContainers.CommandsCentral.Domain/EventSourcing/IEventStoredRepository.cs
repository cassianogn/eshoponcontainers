using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;

namespace Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing
{
    public interface IEventStoredRepository : IEntityRepository<EventStored>
    {
    }
}
