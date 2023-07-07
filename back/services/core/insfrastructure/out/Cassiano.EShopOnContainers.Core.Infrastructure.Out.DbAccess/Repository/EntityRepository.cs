using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository
{
    public abstract class EntityRepository<TEntity> : IReaderRepository<TEntity>, IWriterRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly DbContext DbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected EntityRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();
        }
        protected IQueryable<TEntity> BaseQuery() => _dbSet.Where(entity => !entity.Deleted).AsNoTracking();
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = BaseQuery();
            query = ConfigureQueryOnGetByIdTemplateMethod(query);
            var entity = await query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            return entity;
        }
        protected virtual IQueryable<TEntity> ConfigureQueryOnGetByIdTemplateMethod(IQueryable<TEntity> query) => query;
        public abstract Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey, CancellationToken cancellationToken = default);
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await BaseQuery().FirstAsync(entity => entity.Id == id, cancellationToken);
            entity.SetAsDeleted();
            await UpdateAsync(entity, cancellationToken);

        }
    }
}
