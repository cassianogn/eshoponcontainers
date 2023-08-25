using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.ValueObject;

namespace DTI.Core.Domain.Entities
{
    public abstract class NamedEntity<TEntity> : Entity<TEntity>, INamedEntity where TEntity : Entity<TEntity>
    {
        protected NamedEntity() 
        {
                
        }
        protected NamedEntity(Guid id, string name) : base(id)
        {
            Name = new SearchableStringVO(name);
        }

        public SearchableStringVO Name { get; protected set; }
    }
}
