using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Interfaces.Entities;

namespace DTI.Core.Domain.Interfaces.Repositories
{
    public interface IReaderRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<NamedEntityDTO>> SearchByKeywordAsync(string searchKey = "", CancellationToken cancellationToken = default);

    }
}
