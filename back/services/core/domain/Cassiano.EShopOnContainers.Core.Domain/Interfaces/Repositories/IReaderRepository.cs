using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories
{
    public interface IReaderRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey, CancellationToken cancellationToken = default);

    }
}
