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

        protected override IQueryable<Product> ConfigureQueryOnGetByIdTemplateMethod(IQueryable<Product> query)
        {
            return query.Include(product => product.ProductCategories)
                .ThenInclude(productCategory => productCategory.Category)
                .Include(product => product.ProductColors)
                .ThenInclude(productColor => productColor.Color);
        }

    }
}
