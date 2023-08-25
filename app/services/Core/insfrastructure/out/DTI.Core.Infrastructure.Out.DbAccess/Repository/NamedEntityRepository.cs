using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Helpers.Extensions;
using DTI.Core.Domain.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace DTI.Core.Infrastructure.Out.DbAccess.Repository
{
    public class NamedEntityRepository<TEntity> : EntityRepository<TEntity>
        where TEntity : class, INamedEntity
    {
        public NamedEntityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey = "", CancellationToken cancellationToken = default)
        {
            var query = BaseQueryByKeyword(searchKey);
            query = HandlerQuerySearchByKeywordTemplateMethod(query).OrderBy(entity => entity.Name.Value);
            var result = await query.Select(entity => new NamedEntityDTO() { Id = entity.Id, Name = entity.Name.Value}).Take(30).ToListAsync(cancellationToken: cancellationToken);
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
