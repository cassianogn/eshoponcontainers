using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.FakeEntites
{
    public class EntityTests
    {
        [Trait("Categoria", "Entity")]
        [Fact(DisplayName = "Entity Base Teste")]
        public void Entity_Create_Success()
        {
            // arrage
            Guid entityId = Guid.NewGuid();
            var limitDate = DateTime.UtcNow.AddDays(-1);

            // act
            var entity = new FakeEntity(entityId);

            // assert
            Assert.Equal(entity.Id, entityId);
            Assert.True(entity.CreationDate > limitDate);
            Assert.False(entity.Deleted);
        }

        [Trait("Categoria", "Entity")]
        [Fact(DisplayName = "Named Entity Base Teste")]
        public void FakeEntity_Create_Success()
        {
            // arrage
            Guid entityId = Guid.NewGuid();
            var name = "cassiano";

            // act
            var entity = new FakeNamedEntity(entityId, name);

            // assert
            Assert.Equal("cassiano", entity.Name.Value);
        }
    }
}
