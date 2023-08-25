using DTI.Core.Domain.Services.Validations.Helpers;

namespace EShopOnContainer.BackOffice.Domain.Products.SubEntities.ValidationPolicies
{
    public class ProductColorValidationStrategyPolicy : DomainValidationStrategyPolicy<ProductColor>
    {
        public ProductColorValidationStrategyPolicy(ProductColor entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            IsRequired(entity => entity.ProductId);
            IsRequired(entity => entity.ColorId, "Cor");
            RangeNumberInt(entity => entity.StockQuantity, 9999, 0, "Quantidade em estoque");
        }
    }
}
