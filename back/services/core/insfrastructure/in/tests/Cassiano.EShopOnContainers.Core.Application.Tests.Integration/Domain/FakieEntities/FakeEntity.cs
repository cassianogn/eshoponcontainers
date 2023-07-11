using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.ValueObject;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities
{
    public class FakeEntity : NamedEntity<FakeEntity>, INamedEntity
    {
        private FakeEntity()
        {
        }
        public FakeEntity(Guid id, string name, string description) : base(id, name)
        {
            Description = description;
        }
        public string Description { get; private set; }

        protected override void SetValidationRules()
        {
            base.SetValidationRules();
            AddDomainValidationPolicy(new FakeEntityValidation(this));
        }

        public void Update(string name, string description)
        {
            Name = new SearchableStringVO(name);
            Description = description;
        }
    }
}
