using EShopOnContainer.Catalog.Application.Products.Entities;
using EShopOnContainer.Catalog.Application.Products.Interfaces;

namespace EShopOnContainer.Catalog.Infra.Out.AccessData.Products
{
    internal class ProductRepository : IProductRepository
    {
        public Task Add(ProductModel product)
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProductModel>> GetById(string searchKey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> Search(string searchKey)
        {
            return new List<ProductModel>() { new ProductModel(Guid.NewGuid(), "Test", "Test", 10) };
        }
    }
}
