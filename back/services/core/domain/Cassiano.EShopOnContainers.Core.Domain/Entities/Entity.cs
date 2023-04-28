namespace Cassiano.EShopOnContainers.Core.Domain.Entities
{
    public abstract class Entity
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
