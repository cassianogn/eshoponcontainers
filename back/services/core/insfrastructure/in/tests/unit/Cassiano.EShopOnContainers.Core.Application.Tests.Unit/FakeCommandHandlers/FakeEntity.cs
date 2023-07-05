using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity;
using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers
{
    public class FakeEntity : Entity<FakeEntity>
    {
        public FakeEntity(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected override void SetValidationRules()
        {
            base.SetValidationRules();
            AddDomainValidationPolicy(new FakeEntityValidation(this));
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
