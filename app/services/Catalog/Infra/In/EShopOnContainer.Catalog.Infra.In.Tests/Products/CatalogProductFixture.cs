using EShopOnContainer.Catalog.Application.Products.Entities;

namespace EShopOnContainer.Catalog.Infra.In.Tests.Products
{
    [CollectionDefinition(nameof(CatalogProductCollection))]
    public class CatalogProductCollection : ICollectionFixture<CatalogProductFixture>
    {
    }
    public class CatalogProductFixture
    {
        public ProductModel Product { get; set; }
    }
    

}
