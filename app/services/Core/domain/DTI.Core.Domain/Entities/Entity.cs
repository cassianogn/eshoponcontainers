using DTI.Core.Domain.Entities.Validations;
using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Services.Validations.Helpers;

namespace DTI.Core.Domain.Entities
{
    public abstract class Entity<TEntity> : IEntityWithDomainValidations<TEntity> where TEntity : Entity<TEntity>, IEntity
    {
        private readonly List<DomainValidationStrategyPolicy<TEntity>> _validationStrategyPolicies = new();
        protected Entity()
        {

        }
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

        protected void AddDomainValidationPolicy(DomainValidationStrategyPolicy<TEntity> validationStrategyPolicy) => _validationStrategyPolicies.Add(validationStrategyPolicy);

        public IEnumerable<DomainValidationStrategyPolicy<TEntity>> GetValidationStrategyPolicies()
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
