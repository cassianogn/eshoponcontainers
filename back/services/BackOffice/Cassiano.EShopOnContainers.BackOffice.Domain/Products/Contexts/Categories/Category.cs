using Cassiano.EShopOnContainers.BackOffice.Domain.Products.SubEntities;
using Cassiano.EShopOnContainers.Core.Domain.Entities;

namespace Cassiano.EShopOnContainers.BackOffice.Domain.Products.Contexts.Categories
{
    public class Category : NamedEntity<Category>
    {
        public IReadOnlyCollection<ProductCategory> ProductCategories { get; set; }
    }
}
