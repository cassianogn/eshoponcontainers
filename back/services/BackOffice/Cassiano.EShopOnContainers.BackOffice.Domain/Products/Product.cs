using Cassiano.EShopOnContainers.BackOffice.Domain.Products.SubEntities;
using Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects;
using Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.ValueObject;

namespace Cassiano.EShopOnContainers.BackOffice.Domain.Products
{
    public class Product : NamedEntity<Product>
    {
        private Product() { }
        public Product(Guid id, string name, ProductPriceDTO price, bool enable, string description, IReadOnlyCollection<ProductCategory> productCategories, IReadOnlyCollection<ProductColor> productColors) : base(id, name)
        {
            Price = new ProductPriceVO(price.Sale, price.Cost);
            if (enable)
                SetAsEnable();
            else
                SetAsDisable();
            Description = description;
            ProductCategories = productCategories;
            ProductColors = productColors;
        }
        public ProductPriceVO Price { get; private set; }
        public bool Enable { get; private set; }
        public string Description { get; private set; }
        public DateTime? EnableDate { get; private set; }
        public DateTime? DisableDate { get; private set; }
        public IReadOnlyCollection<ProductCategory> ProductCategories { get; private set; }
        public IReadOnlyCollection<ProductColor> ProductColors { get; private set; }
        public void SetAsEnable()
        {
            Enable = true;
            EnableDate = DateTime.Now;
        }

        public void SetAsDisable()
        {
            Enable = false;
            DisableDate = DateTime.Now;
        }

        protected override void SetValidationRules()
        {
            AddDomainValidationPolicy(new ProductValidationStrategyPolicy(this));
            base.SetValidationRules();
        }

        public void UpdateFormData(string name, ProductPriceDTO price, string description, IReadOnlyCollection<ProductCategory> productCategories, IReadOnlyCollection<ProductColor> productColors)
        {
            Name = new SearchableStringVO(name);
            Price = new ProductPriceVO(price.Sale, price.Cost);
            Description = description;
            ProductCategories = productCategories;
            ProductColors = productColors;
        }
    }
}
