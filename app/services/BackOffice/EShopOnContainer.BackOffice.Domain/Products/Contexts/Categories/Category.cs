using EShopOnContainer.BackOffice.Domain.Products.SubEntities;
using DTI.Core.Domain.Entities;
using DTI.Core.Domain.ValueObject;

namespace ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories
{
    public class Category : NamedEntity<Category>
    {
        private Category() { }
        public Category(Guid id, string name) : base(id, name)
        {
        }

        public void SetName(string name)
        {
            Name = new SearchableStringVO(name);
        }

        public IReadOnlyCollection<ProductCategory> ProductCategories { get; set; }
    }
}
