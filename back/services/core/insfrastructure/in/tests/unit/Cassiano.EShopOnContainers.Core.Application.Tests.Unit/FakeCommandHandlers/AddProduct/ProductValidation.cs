using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.AddProduct
{
    internal class ProductValidation : DomainValidationStrategyPolicy<Product>
    {
        public ProductValidation(Product entity) : base(entity)
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
