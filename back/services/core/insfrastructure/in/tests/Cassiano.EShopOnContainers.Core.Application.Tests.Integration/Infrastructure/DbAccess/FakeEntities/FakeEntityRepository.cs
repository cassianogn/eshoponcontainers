using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities
{
    internal class FakeEntityRepository : NamedEntityRepository<FakeEntity>
    {
        public FakeEntityRepository(TestDb dbContext) : base(dbContext)
        {
        }
    }
}
