using EShopOnContainer.BackOffice.Domain.Products.ValueObjects.ValidationsPolicies;
using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Services.Validations.Helpers;

namespace EShopOnContainer.BackOffice.Domain.Products.ValueObjects
{
    public class ProductPriceVO : IClassWithDomainValidations<ProductPriceVO>
    {
        private ProductPriceVO() { }

        public ProductPriceVO(double sale, double provide)
        {
            Sale = sale;
            Cost = provide;
        }

        public double Sale { get; private set; } 
        public double Cost { get; private set; }

        public IEnumerable<DomainValidationStrategyPolicy<ProductPriceVO>> GetValidationStrategyPolicies()
        {
            return new List<DomainValidationStrategyPolicy<ProductPriceVO>>
            {
                new ProductPriceValidationStrategyPolicy(this)
            };
        }
    }
}
