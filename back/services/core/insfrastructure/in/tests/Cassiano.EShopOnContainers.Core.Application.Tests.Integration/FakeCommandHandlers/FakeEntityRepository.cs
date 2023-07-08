using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
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
            return Task.FromResult(new FakeEntity(id, "name", "FakeEntity", "FakeEntity"));
        }

     
        public Task AddAsync(FakeEntity entity, CancellationToken cancellationToken = default) => Task.CompletedTask;    
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public Task UpdateAsync(FakeEntity entity, CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey, CancellationToken cancellationToken = default)
        {

            var fakeEntities = new List<NamedEntityDTO>
            {
                new NamedEntityDTO() { Id = Guid.NewGuid(), Name = "FakeEntity1" }, 
                new NamedEntityDTO() { Id = Guid.NewGuid(), Name = "FakeEntity2" },
                new NamedEntityDTO() { Id = Guid.NewGuid(), Name = "FakeEntity3" }
            };

            return Task.FromResult(fakeEntities as IEnumerable<NamedEntityDTO>);

        }
    }
}
