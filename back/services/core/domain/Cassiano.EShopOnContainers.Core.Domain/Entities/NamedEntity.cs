using Cassiano.EShopOnContainers.Core.Domain.ValueObject;

namespace Cassiano.EShopOnContainers.Core.Domain.Entities
{
    public abstract class NamedEntity : Entity
    {
        protected NamedEntity(Guid id) : base(id)
        {
        }

        public NameVO Name { get; private set; }
    }
}
