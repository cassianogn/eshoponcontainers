using EShopOnContainer.Catalog.Application.Products.Entities;

namespace EShopOnContainer.Catalog.Infra.In.Tests.Products
{
    [CollectionDefinition(nameof(CatalogProductCollection))]
    public class CatalogProductCollection : ICollectionFixture<CatalogProductFixture>
    {
    }
    internal class CatalogProductFixture
    {
        public ProductModel Product { get; set; }
    }
    

}
