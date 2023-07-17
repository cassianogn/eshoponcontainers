using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository;
using Microsoft.EntityFrameworkCore;
using ShopOnContainers.BackOffice.Domain.Products;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products
{
    internal class ProductRepository : NamedEntityRepository<Product>, IProductRepository
    {
        public ProductRepository(BackOfficeDb dbContext) : base(dbContext)
        {
        }
    }
}
