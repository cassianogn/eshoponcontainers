using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.Interfaces.Entities;

namespace DTI.Core.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<TEntity> : IReaderRepository<TEntity>, IWriterRepository<TEntity> 
        where TEntity: IEntity
    {
    }
}
