using DTI.Core.Domain.ValueObject;

namespace DTI.Core.Domain.Interfaces.Entities
{
    public interface INamedEntity : IEntity
    {
        public SearchableStringVO Name { get; }

    }
}
