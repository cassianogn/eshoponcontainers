using DTI.Core.Domain.Services.Validations.Helpers;
using DTI.Core.Domain.Tests.Unit.Validations.Service;

namespace DTI.Core.Domain.Tests.Unit.Validations.Service.Policies
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
