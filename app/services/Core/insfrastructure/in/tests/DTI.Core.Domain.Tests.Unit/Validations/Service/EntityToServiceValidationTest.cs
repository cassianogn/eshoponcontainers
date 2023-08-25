using DTI.Core.Domain.Entities;
using DTI.Core.Domain.Tests.Unit.Validations.Service.Policies;
using System;

namespace DTI.Core.Domain.Tests.Unit.Validations.Service
{
    public class EntityToServiceValidationTest : Entity<EntityToServiceValidationTest>
    {
        public EntityToServiceValidationTest(Guid id, string description, string customValue) : base(id)
        {
            Description = description;
            CustomValue = customValue;
        }

        public string Description { get; private set; }
        public string CustomValue { get; private set; }

        protected override void SetValidationRules()
        {
            AddDomainValidationPolicy(new EntityValidatePorpertiesStrategyPolicy(this));
            base.SetValidationRules();
        }
    }
}
