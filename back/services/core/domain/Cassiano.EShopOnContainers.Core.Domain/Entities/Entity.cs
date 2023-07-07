using Cassiano.EShopOnContainers.Core.Domain.Entities.Validations;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;

namespace Cassiano.EShopOnContainers.Core.Domain.Entities
{
    public abstract class Entity<TEntity> : IEntityWithDomainValidations<TEntity> where TEntity : Entity<TEntity>, IEntity
    {
        private readonly List<IValidationStrategyPolicy<TEntity>> _validationStrategyPolicies = new();

        protected Entity(Guid id)
        {
            Id = id;
            Deleted = false;
            CreationDate = DateTime.UtcNow;

        }

        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool Deleted { get; private set; }
        public DateTime DeletedDate { get; private set; }

        protected void AddDomainValidationPolicy(IValidationStrategyPolicy<TEntity> validationStrategyPolicy) => _validationStrategyPolicies.Add(validationStrategyPolicy);

        public IEnumerable<IValidationStrategyPolicy<TEntity>> GetValidationStrategyPolicies()
        {
            if (!_validationStrategyPolicies.Any())
                SetValidationRules();
            return _validationStrategyPolicies.ToList();
        }
        protected virtual void SetValidationRules()
        {
            AddDomainValidationPolicy(new EntityValidationStrategyPolicy<TEntity>((TEntity)this));
        }

        public void SetAsDeleted()
        {
            Deleted = true;
            DeletedDate = DateTime.UtcNow;
        }
    }
}
