using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.FakeEntites
{
    internal class FakeEntity : Entity
    {
        public FakeEntity(Guid id) : base(id)
        {
        }
    }
}
