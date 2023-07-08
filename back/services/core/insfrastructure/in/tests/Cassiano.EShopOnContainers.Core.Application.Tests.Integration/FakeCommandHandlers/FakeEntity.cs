using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers
{
    public class FakeEntity : NamedEntity<FakeEntity>, INamedEntity
    {
        public FakeEntity(Guid id, string name, string subname, string description) : base(id, name)
        {
            SubName = subname;
            Description = description;
        }
        public string SubName { get; private set; }
        public string Description { get; private set; }

        protected override void SetValidationRules()
        {
            base.SetValidationRules();
            AddDomainValidationPolicy(new FakeEntityValidation(this));
        }

        public void Update(string subname, string description)
        {
            SubName = subname;
            Description = description;
        }
    }
}
