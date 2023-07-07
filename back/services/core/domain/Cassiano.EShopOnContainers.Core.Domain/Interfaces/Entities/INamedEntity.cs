using Cassiano.EShopOnContainers.Core.Domain.ValueObject;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities
{
    public interface INamedEntity : IEntity
    {
        public SearchableStringVO Name { get; }

    }
}
