using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers
{
    public class FakeEntityRepository : IFakeEntityRepository
    {

        public Task<FakeEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new FakeEntity(id, "FakeEntity", "FakeEntity"));
        }

        public Task<IEnumerable<FakeEntity>> GetBySearchKeyAsync(string searchKey, CancellationToken cancellationToken = default)
        {
            var fakeEntities = new List<FakeEntity>
            {
                new FakeEntity(Guid.NewGuid(), "FakeEntity1", "FakeEntity1"),
                new FakeEntity(Guid.NewGuid(), "FakeEntity2", "FakeEntity2"),
                new FakeEntity(Guid.NewGuid(), "FakeEntity3", "FakeEntity3")
            };

            return Task.FromResult(fakeEntities as IEnumerable<FakeEntity>);
        }

        public Task AddAsync(FakeEntity entity, CancellationToken cancellationToken = default) => Task.CompletedTask;    
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public Task UpdateAsync(FakeEntity entity, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
