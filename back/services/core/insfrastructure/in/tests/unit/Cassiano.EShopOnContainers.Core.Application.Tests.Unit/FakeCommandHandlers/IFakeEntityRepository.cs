using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers
{
    public interface IFakeEntityRepository : IWriterRepository<FakeEntity>, IReaderRepository<FakeEntity>
    {
    }
}
