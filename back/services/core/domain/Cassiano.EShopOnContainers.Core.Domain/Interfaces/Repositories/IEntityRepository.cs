using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<TEntity> : IReaderRepository<TEntity>, IWriterRepository<TEntity> where TEntity: IEntity
    {
    }
}
