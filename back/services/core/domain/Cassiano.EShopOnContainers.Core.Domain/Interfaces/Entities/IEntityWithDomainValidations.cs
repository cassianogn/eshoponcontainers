using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;

namespace Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities
{
    public interface IEntityWithDomainValidations<TEntity> : IEntity, IClassWithDomainValidations<TEntity> where TEntity : IEntity
    {
    }
}
