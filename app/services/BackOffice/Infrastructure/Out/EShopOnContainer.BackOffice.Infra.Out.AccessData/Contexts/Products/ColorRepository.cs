using DTI.Core.Infra.Out.DbAccess.Repository;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products
{
    internal class ColorRepository : NamedEntityRepository<Color>, IColorRepository
    {
        public ColorRepository(BackOfficeDb dbContext) : base(dbContext)
        {
        }
    }
}
