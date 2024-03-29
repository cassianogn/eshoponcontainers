﻿using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DTI.Core.Infra.Out.DbAccess.Repository
{
    public abstract class EntityRepository<TEntity> : IReaderRepository<TEntity>, IWriterRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected EntityRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();
        }
        protected IQueryable<TEntity> BaseQuery() => _dbSet.Where(entity => !entity.Deleted);
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = BaseQuery();
            query = ConfigureQueryOnGetByIdTemplateMethod(query);
            var entity = await query.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            return entity;
        }
        protected virtual IQueryable<TEntity> ConfigureQueryOnGetByIdTemplateMethod(IQueryable<TEntity> query) => query;
        public abstract Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey = "", CancellationToken cancellationToken = default);
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {

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
