using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Policies
{
    internal class EntityValidatePorpertiesStrategyPolicy : DomainValidationStrategyPolicy<EntityToValidationTest>
    {
        public EntityValidatePorpertiesStrategyPolicy(EntityToValidationTest entity) : base(entity)
        {
        }

        protected override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Description);
        }
    }
}
