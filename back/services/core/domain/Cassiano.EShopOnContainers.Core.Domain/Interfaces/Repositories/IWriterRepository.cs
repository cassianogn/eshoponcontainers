using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories
{
    public interface IWriterRepository<TEntity> where TEntity : IEntity
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
