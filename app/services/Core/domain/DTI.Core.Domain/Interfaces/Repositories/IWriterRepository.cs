using DTI.Core.Domain.Interfaces.Entities;

namespace DTI.Core.Domain.Interfaces.Repositories
{
    public interface IWriterRepository<in TEntity> where TEntity : IEntity
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
