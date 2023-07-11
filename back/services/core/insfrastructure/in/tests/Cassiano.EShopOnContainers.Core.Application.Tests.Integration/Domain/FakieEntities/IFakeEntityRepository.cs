using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities
{
    public interface IFakeEntityRepository : IWriterRepository<FakeEntity>, IReaderRepository<FakeEntity>
    {
    }
}
