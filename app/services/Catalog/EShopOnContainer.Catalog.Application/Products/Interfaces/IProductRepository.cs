using EShopOnContainer.Catalog.Application.Products.Entities;

namespace EShopOnContainer.Catalog.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        public Task Add(ProductModel product);
        public Task<IEnumerable<ProductModel>> Search(string searchKey);
        public Task<IEnumerable<ProductModel>> GetById(string searchKey);
    }
}
