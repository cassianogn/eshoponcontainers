using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Services.Validations.Helpers;

namespace DTI.Core.Domain.Entities.Validations
{
    public class NamedEntityValidationStrategyPolicy<TEntity> : DomainValidationStrategyPolicy<TEntity> where TEntity : INamedEntity
    {
        public NamedEntityValidationStrategyPolicy(TEntity entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            BasicValidationsToTextField(entity => entity.Name.Value, "Name", true);
        }
    }
}
