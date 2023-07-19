using Cassiano.EShopOnContainers.BackOffice.Domain.Products.SubEntities;
using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.ValueObject;

namespace ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors
{
    public class Color : NamedEntity<Color>
    {
        public Color(Guid id, string name) : base(id, name)
        {
        }

        public IReadOnlyCollection<ProductColor> ProductColors { get; private set; }

        public void SetName(string name)
        {
            Name = new SearchableStringVO(name);
        }
    }
}
