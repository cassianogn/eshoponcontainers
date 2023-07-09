using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.FakeCommandHandlers
{
    [CollectionDefinition(nameof(FakeEntityHandlerCollection))]
    public class FakeEntityHandlerCollection : ICollectionFixture<FakeEntityHandlerFixture>
    {
    }

    public class FakeEntityHandlerFixture
    {
        public FakeEntity AddedFakeEntity { private set; get; }
        public void AddFakeEntity(FakeEntity fakeEntity) => AddedFakeEntity = fakeEntity;
    }
}
