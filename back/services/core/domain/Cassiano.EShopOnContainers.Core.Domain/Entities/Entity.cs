using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;

namespace Cassiano.EShopOnContainers.Core.Domain.Entities
{
    public abstract class Entity: IEntity
    {
        protected Entity(Guid id)
        {
            Id = id;
            Deleted = false;
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public bool Deleted { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
