using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.Cars
{
    internal class CarValidation : DomainValidationStrategyPolicy<Car>
    {
        public CarValidation(Car entity) : base(entity)
        {
        }

        protected override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Id);
            
            IsRequired((entityValidate) => entityValidate.Name);
            MaxLength((entityValidate) => entityValidate.Name);
            MinLength((entityValidate) => entityValidate.Name);
            
            IsRequired((entityValidate) => entityValidate.Description);
            MaxLength((entityValidate) => entityValidate.Description, "", 200);
            MinLength((entityValidate) => entityValidate.Description);

            _validationRule.RuleFor(test => test.Deleted);
        }
    }
  
}
