using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities
{
    public interface IEntityWithDomainValidations<TEntity> : IEntity where TEntity : IEntity
    {
        IEnumerable<IValidationStrategyPolicy<TEntity>> GetValidationStrategyPolicies();
    }
}
