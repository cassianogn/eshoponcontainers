using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers
{
    public class FakeEntityRepository : NamedEntityRepository<FakeEntity>, IFakeEntityRepository
    {
        public FakeEntityRepository(TestDb dbContext) : base(dbContext)
        {
        }

    }
}
