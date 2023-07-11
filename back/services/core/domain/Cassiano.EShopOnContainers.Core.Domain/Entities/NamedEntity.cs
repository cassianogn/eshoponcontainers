using Cassiano.EShopOnContainers.Core.Domain.ValueObject;

namespace Cassiano.EShopOnContainers.Core.Domain.Entities
{
    public abstract class NamedEntity<TEntity> : Entity<TEntity> where TEntity : Entity<TEntity>
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
