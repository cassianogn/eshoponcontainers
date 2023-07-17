using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities
{
    public interface IClassWithDomainValidations<TClassWithValidations>
    {
        IEnumerable<DomainValidationStrategyPolicy<TClassWithValidations>> GetValidationStrategyPolicies();
    }
}
