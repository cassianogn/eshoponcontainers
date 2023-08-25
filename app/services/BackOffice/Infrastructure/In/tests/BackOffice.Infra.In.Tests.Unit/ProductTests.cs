using EShopOnContainer.BackOffice.Domain.Products;
using EShopOnContainer.BackOffice.Domain.Products.SubEntities;
using EShopOnContainer.BackOffice.Domain.Products.ValueObjects.DTOs;

namespace BackOffice.Infra.In.Tests.Unit
{
    public class ProductTests
    {
        [Trait("Category", "Unit BackOffice Product")]
        [Fact(DisplayName = "1 - Product valid")]
        public void ProductValidationStrategyPolicy_ShouldBeValid()
        {
            var product = GetValidProduct();
            var validation = new ProductValidationStrategyPolicy(product);
            var result = validation.ValidateAsync(product).Result;
            Assert.True(result.IsValid);
        }
        [Trait("Category", "Unit BackOffice Product")]
        [Fact(DisplayName = "2 - Product invalid")]
        public void ProductValidationStrategyPolicy_ShouldBeInvalid()
        {
            var product = GetInvalidProduct();
            var validation = new ProductValidationStrategyPolicy(product);
            var result = validation.ValidateAsync(product).Result;
            Assert.False(result.IsValid);
            Assert.Equal(8, result.Errors.Count);
            Assert.Single(result.Errors.Where(error => error == "Nome is required"));
            Assert.Single(result.Errors.Where(error => error == "Descrição is required"));
            Assert.Single(result.Errors.Where(error => error == "preço de venda precisa ser maior que o de custo"));
            Assert.Single(result.Errors.Where(error => error == "Categoria item is already on the list"));
            Assert.Single(result.Errors.Where(error => error == "Cor item is already on the list"));
            Assert.Single(result.Errors.Where(error => error == "Cores 1 - Quantidade em estoque must be at least 0"));
        }

        public Product GetValidProduct()
        {
            var productId = Guid.NewGuid();
            return new Product(productId
                , "Product Test"
                , new ProductPriceDTO() { Cost = 10, Sale = 20 }
                , true
                , "teste description"
                , new List<ProductCategory>() { new ProductCategory(Guid.NewGuid(), productId, Guid.NewGuid()), new ProductCategory(Guid.NewGuid(), productId, Guid.NewGuid()) }
                , new List<ProductColor>() { new ProductColor(Guid.NewGuid(), productId, Guid.NewGuid(), 10), new ProductColor(Guid.NewGuid(), productId, Guid.NewGuid(), 10) }
                );
        }
        public Product GetInvalidProduct()
        {
            var productId = Guid.NewGuid();
            var colorId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            return new Product(productId
                               , ""
                               , new ProductPriceDTO() { Cost = 100, Sale = 20 }
                               , true
                               , ""
                               , new List<ProductCategory>() { new ProductCategory(Guid.NewGuid(), productId, categoryId), new ProductCategory(Guid.NewGuid(), productId, categoryId) }
                               , new List<ProductColor>() { new ProductColor(Guid.NewGuid(), productId, colorId, -1), new ProductColor(Guid.NewGuid(), productId, colorId, 10) }
            );
        }
    }
}