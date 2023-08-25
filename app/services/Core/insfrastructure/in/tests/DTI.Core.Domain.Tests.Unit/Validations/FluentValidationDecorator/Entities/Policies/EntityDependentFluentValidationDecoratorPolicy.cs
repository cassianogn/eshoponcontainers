using DTI.Core.Domain.Services.Validations.Helpers;

namespace DTI.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities.Policies
{
    internal class EntityDependentFluentValidationDecoratorPolicy : DomainValidationStrategyPolicy<EntityDependentFluentValidationDecorator>
    {
        public EntityDependentFluentValidationDecoratorPolicy(EntityDependentFluentValidationDecorator entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Name);
            IsRequired((entityValidate) => entityValidate.Organization);
            IsRequired((entityValidate) => entityValidate.Id);
        }
    }
}
