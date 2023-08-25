using EShopOnContainer.BackOffice.Domain.Products.SubEntities;
using DTI.Core.Domain.Entities;
using DTI.Core.Domain.ValueObject;

namespace ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors
{
    public class Color : NamedEntity<Color>
    {
        private Color()
        {
        }
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
