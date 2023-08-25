using DTI.Core.Infrastructure.Out.DbAccess.Repository;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products
{
    internal class CategoryRepository : NamedEntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BackOfficeDb dbContext) : base(dbContext)
        {
        }
    }
}
