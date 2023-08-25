using DTI.Core.Domain.Services.Validations;

namespace DTI.Core.Domain.Interfaces.Entities
{
    public interface IEntityWithDomainValidations<TEntity> : IEntity, IClassWithDomainValidations<TEntity> where TEntity : IEntity
    {
    }
}
