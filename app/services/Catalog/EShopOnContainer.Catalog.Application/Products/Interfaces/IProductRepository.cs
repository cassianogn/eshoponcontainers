using EShopOnContainer.Catalog.Application.Products.Entities;

namespace EShopOnContainer.Catalog.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        public Task Add(ProductModel product);
        public Task<ProductModel?> GetById(Guid searchKey);
        public Task<IReadOnlyCollection<ProductModel>> Search(int page, string? name = null, string? description = null, double? price = null);
    }
}
