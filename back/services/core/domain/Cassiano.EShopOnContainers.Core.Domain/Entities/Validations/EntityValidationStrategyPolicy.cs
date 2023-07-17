using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;

namespace Cassiano.EShopOnContainers.Core.Domain.Entities.Validations
{
    public class EntityValidationStrategyPolicy<TEntity> : DomainValidationStrategyPolicy<TEntity> where TEntity : IEntity
    {
        public EntityValidationStrategyPolicy(TEntity entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            IsRequired((entityValidate) => entityValidate.Id);
        }
    }
}
