using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace DTI.Core.Application.Tests.Integration.Domain.FakieEntities
{
    public interface IFakeEntityRepository : IWriterRepository<FakeEntity>, IReaderRepository<FakeEntity>
    {
    }
}
