using DTI.Core.Application.Tests.Integration.Domain.FakieEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeControllers
{
    [CollectionDefinition(nameof(FakeControllerCollection))]
    public class FakeControllerCollection : ICollectionFixture<FakeControllerFixture>
    {
    }

    public class FakeControllerFixture
    {
        public FakeEntity AddedFakeEntity { private set; get; }
        public void AddFakeEntity(FakeEntity fakeEntity) => AddedFakeEntity = fakeEntity;
    }
}
