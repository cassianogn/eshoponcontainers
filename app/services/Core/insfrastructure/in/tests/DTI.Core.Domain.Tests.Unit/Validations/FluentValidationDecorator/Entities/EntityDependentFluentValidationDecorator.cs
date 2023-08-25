using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Services.Validations.Helpers;
using DTI.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities.Policies;
using System;
using System.Collections.Generic;

namespace DTI.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities
{
    public class EntityDependentFluentValidationDecorator : IClassWithDomainValidations<EntityDependentFluentValidationDecorator>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }

        public IEnumerable<DomainValidationStrategyPolicy<EntityDependentFluentValidationDecorator>> GetValidationStrategyPolicies()
        {
            return new List<DomainValidationStrategyPolicy<EntityDependentFluentValidationDecorator>>
            {
                new EntityDependentFluentValidationDecoratorPolicy(this)
            };
        }
    }
}
