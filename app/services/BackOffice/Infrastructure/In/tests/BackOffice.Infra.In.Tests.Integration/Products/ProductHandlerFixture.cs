using Cassiano.EShopOnContainers.BackOffice.Domain.Products;

namespace BackOffice.Infra.In.Tests.Integration.Products
{
    [CollectionDefinition(nameof(ProductHandlerCollection))]
    public class ProductHandlerCollection : ICollectionFixture<ProductHandlerFixture>
    {
    }
    public class ProductHandlerFixture
    {
        public Product AddedProduct { private set; get; }
        public void AddProduct(Product product) => AddedProduct = product;
    }
}
