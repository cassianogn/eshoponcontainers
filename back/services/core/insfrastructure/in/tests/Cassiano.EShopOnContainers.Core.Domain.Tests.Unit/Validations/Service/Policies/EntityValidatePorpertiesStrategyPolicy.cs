using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Service;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Service.Policies
{
    internal class EntityValidatePorpertiesStrategyPolicy : DomainValidationStrategyPolicy<EntityToServiceValidationTest>
    {
        public EntityValidatePorpertiesStrategyPolicy(EntityToServiceValidationTest entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Description);
        }
    }
}
