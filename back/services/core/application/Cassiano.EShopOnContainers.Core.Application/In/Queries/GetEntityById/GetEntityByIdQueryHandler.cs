using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Queries.GetEntityById
{
    public abstract class GetEntityByIdQueryHandler<TEntity, TRepository, TQuery, TViewModel> : BaseRequestHandler<TQuery, TViewModel?>
        where TEntity : IEntity
        where TRepository : IReaderRepository<TEntity>
        where TQuery : IEntityDTO, IAppMessage<TViewModel?>

    {
        protected readonly TRepository Repository;

        public GetEntityByIdQueryHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            Repository = repository;
        }

        public override async Task<CommandResult<TViewModel?>> ExecuteAsync(TQuery request, CancellationToken cancellationToken)
        {
            var entity = await Repository.GetByIdAsync(request.Id, cancellationToken);
            var entityViewModel = MapEntityToViewModel(entity);
            return CommandResult<TViewModel?>.CommandFinished(entityViewModel);
        }

        protected abstract TViewModel? MapEntityToViewModel(TEntity entity);

        protected override EventType GetEventType() => EventType.Query;
    }
}
