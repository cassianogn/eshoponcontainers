using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Services.Validations.Helpers;

namespace DTI.Core.Domain.Entities.Validations
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
