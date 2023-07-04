using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.ValueObject;

namespace Cassiano.EShopOnContainers.Core.Domain.Entities
{
    public abstract class NamedEntity<TEntity> : Entity<TEntity> where TEntity : Entity<TEntity>
    {
        protected NamedEntity(Guid id, string name) : base(id)
        {
            Name = new NameVO(name);
        }

        public NameVO Name { get; private set; }
    }
}
