using Cassiano.EShopOnContainers.BackOffice.Domain.Products.SubEntities.ValidationPolicies;
using Cassiano.EShopOnContainers.Core.Domain.Entities;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;

namespace Cassiano.EShopOnContainers.BackOffice.Domain.Products.SubEntities
{
    public class ProductCategory : Entity<ProductCategory>
    {
        public ProductCategory(Guid id,Guid productId, Guid categoryId): base (id)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public Guid ProductId { get; private set; }
        public Guid CategoryId { get; private set; }

        public Product Product { get; private set; }
        public Category Category { get; private set; }

        protected override void SetValidationRules()
        {
            AddDomainValidationPolicy(new ProductCategoryValidationStrategyPolicy(this));
            base.SetValidationRules();
        }
    }
}
