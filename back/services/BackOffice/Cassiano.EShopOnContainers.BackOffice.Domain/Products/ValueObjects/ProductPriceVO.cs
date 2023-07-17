using Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects.ValidationsPolicies;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects
{
    public class ProductPriceVO : IClassWithDomainValidations<ProductPriceVO>
    {
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
