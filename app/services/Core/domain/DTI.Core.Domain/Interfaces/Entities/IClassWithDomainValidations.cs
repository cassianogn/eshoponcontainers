using DTI.Core.Domain.Services.Validations;
using DTI.Core.Domain.Services.Validations.Helpers;

namespace DTI.Core.Domain.Interfaces.Entities
{
    public interface IClassWithDomainValidations<TClassWithValidations>
    {
        IEnumerable<DomainValidationStrategyPolicy<TClassWithValidations>> GetValidationStrategyPolicies();
    }
}
