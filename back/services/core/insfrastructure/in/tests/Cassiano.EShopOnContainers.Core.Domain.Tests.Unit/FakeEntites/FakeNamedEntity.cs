using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.FakeEntites
{
    internal class FakeNamedEntity : NamedEntity<FakeNamedEntity>
    {
        public FakeNamedEntity(Guid id, string name) : base(id, name)
        {
        }
    }
}
