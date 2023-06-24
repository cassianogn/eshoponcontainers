using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity
{
    public class FakeEntity : Entity
    {
        public FakeEntity(Guid id) : base(id)
        {
        }
    }
}
