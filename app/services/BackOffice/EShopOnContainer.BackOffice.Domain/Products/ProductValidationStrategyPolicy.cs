using DTI.Core.Domain.Services.Validations.Helpers;

namespace EShopOnContainer.BackOffice.Domain.Products
{
    public class ProductValidationStrategyPolicy : DomainValidationStrategyPolicy<Product>
    {
        public ProductValidationStrategyPolicy(Product entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            BasicValidationsToTextField(entity => entity.Description, "Descrição");
            BasicValidationsToTextField(entity => entity.Name.Value, "Nome");
            AddValidationsFromDependentProperty(entity => entity.Price, "Preço");
            AddValidationsFromDependentListProperty(entity => entity.ProductCategories, "Categorias");
            DontRepeatDependentListItemProperty(entity => entity.ProductCategories.Select(productCategory => productCategory.CategoryId), "Categoria");
            DontRepeatDependentListItemProperty(entity => entity.ProductColors.Select(productColor => productColor.ColorId), "Cor");
            AddValidationsFromDependentListProperty(entity => entity.ProductColors, "Cores");

            IsRequired(entity => entity.EnableDate, "Data de disponibilidade", entity => entity.Enable);
            IsRequired(entity => entity.DisableDate, "Data de remoção", entity => !entity.Enable);


        }
    }
}