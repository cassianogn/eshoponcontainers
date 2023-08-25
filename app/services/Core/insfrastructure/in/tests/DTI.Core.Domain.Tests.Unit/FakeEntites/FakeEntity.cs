using DTI.Core.Domain.Entities;
using System;

namespace DTI.Core.Domain.Tests.Unit.FakeEntites
{
    internal class FakeEntity : Entity<FakeEntity>
    {
        public FakeEntity(Guid id) : base(id)
        {
        }
    }
}
