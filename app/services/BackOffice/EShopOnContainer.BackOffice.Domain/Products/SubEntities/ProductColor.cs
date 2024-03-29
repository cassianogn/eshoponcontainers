﻿using EShopOnContainer.BackOffice.Domain.Products.SubEntities.ValidationPolicies;
using DTI.Core.Domain.Entities;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Domain.Products.SubEntities
{
    public class ProductColor : Entity<ProductColor>
    {
        public ProductColor(Guid id, Guid productId, Guid colorId, int stockQuantity) : base(id)
        {
            ProductId = productId;
            ColorId = colorId;
            StockQuantity = stockQuantity;
        }

        public Guid ProductId { get; private set; }
        public Guid ColorId { get; private set; }
        public int StockQuantity { get; private set; }

        public Product Product { get; private set; }
        public Color Color { get; private set; }

        protected override void SetValidationRules()
        {
            AddDomainValidationPolicy(new ProductColorValidationStrategyPolicy(this));
            base.SetValidationRules();
        }
    }
}
