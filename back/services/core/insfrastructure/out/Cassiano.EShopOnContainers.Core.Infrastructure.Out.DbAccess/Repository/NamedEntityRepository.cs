using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Helpers.Extensions;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository
{
    public class NamedEntityRepository<TEntity> : EntityRepository<TEntity>
        where TEntity : class, INamedEntity
    {
        public NamedEntityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey, CancellationToken cancellationToken = default)
        {
            var query = BaseQueryByKeyword(searchKey);
            query = HandlerQuerySearchByKeywordTemplateMethod(query).OrderBy(entity => entity.Name.Value);

            var result = await query.Select(entity => new NamedEntityDTO() { Id = entity.Id, Name = entity.Name.Value }).ToListAsync(cancellationToken: cancellationToken);
            return result;
        }

        protected IQueryable<TEntity> BaseQueryByKeyword(string searchKey)
        {
            searchKey = searchKey.ToSerachable();
            var query = BaseQuery();
            query = query.Where(entity => entity.Name.SearchableValue.Contains(searchKey));
            return query;
        }

        public virtual IQueryable<TEntity> HandlerQuerySearchByKeywordTemplateMethod(IQueryable<TEntity> query) => query;
    }
}
