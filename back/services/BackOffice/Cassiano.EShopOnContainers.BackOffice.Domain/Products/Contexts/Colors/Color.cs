using Cassiano.EShopOnContainers.BackOffice.Domain.Products.SubEntities;
using Cassiano.EShopOnContainers.Core.Domain.Entities;

namespace Cassiano.EShopOnContainers.BackOffice.Domain.Products.Contexts.Colors
{
    public class Color : NamedEntity<Color>
    {
        private Color() { }
        public IReadOnlyCollection<ProductColor> ProductColors { get; private set; }
    }
}
