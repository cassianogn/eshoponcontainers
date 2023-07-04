using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity
{
    internal class FakeEntityValidation : DomainValidationStrategyPolicy<FakeEntity>
    {
        public FakeEntityValidation(FakeEntity entity) : base(entity)
        {
        }

        protected override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Id);
            
            IsRequired((entityValidate) => entityValidate.Name);
            MaxLength((entityValidate) => entityValidate.Name);
            MinLength((entityValidate) => entityValidate.Name);
            
            IsRequired((entityValidate) => entityValidate.Description);
            MaxLength((entityValidate) => entityValidate.Description);
            MinLength((entityValidate) => entityValidate.Description);
        }
    }
}
