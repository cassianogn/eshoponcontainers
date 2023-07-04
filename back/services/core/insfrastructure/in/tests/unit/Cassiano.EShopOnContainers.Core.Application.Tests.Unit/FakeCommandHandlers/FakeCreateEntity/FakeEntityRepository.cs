using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity
{
    public class FakeEntityRepository : IFakeEntityRepository
    {
        public Task AddAsync(FakeEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(FakeEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync(FakeEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
