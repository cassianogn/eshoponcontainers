using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers
{
    internal class FakeEntityValidation : DomainValidationStrategyPolicy<FakeEntity>
    {
        public FakeEntityValidation(FakeEntity entity) : base(entity)
        {
        }

        protected override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Id);

            IsRequired((entityValidate) => entityValidate.SubName);
            MaxLength((entityValidate) => entityValidate.SubName);
            MinLength((entityValidate) => entityValidate.SubName);

            IsRequired((entityValidate) => entityValidate.Description);
            MaxLength((entityValidate) => entityValidate.Description);
            MinLength((entityValidate) => entityValidate.Description);
        }
    }
}
