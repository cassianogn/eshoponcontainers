using DTI.Core.Domain.EventSourcing;
using DTI.Core.Domain.Helpers.Exceptions;
using DTI.Core.Domain.Interfaces.DTOs;
using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Interfaces.Repositories;
using DTI.Core.Domain.Services.Bus.Bases;
using DTI.Core.Domain.Services.Bus.Interfaces;
using DTI.Core.Domain.Services.Bus.Models;
using MediatR;

namespace DTI.Core.Application.In.Queries.GetEntityById
{
    public abstract class GetEntityByIdQueryHandler<TEntity, TRepository, TQuery, TViewModel> : BaseRequestHandler<TQuery, TViewModel>
        where TEntity : IEntity
        where TRepository : IReaderRepository<TEntity>
        where TQuery : IEntityDTO, IAppMessage<TViewModel>

    {
        protected readonly TRepository Repository;

        protected GetEntityByIdQueryHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            Repository = repository;
        }

        public override async Task<CommandResult<TViewModel>> ExecuteAsync(TQuery request, CancellationToken cancellationToken)
        {
            var entity = await Repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                throw new ApplicationCoreException($"Entity {typeof(TEntity).Name} with id {request.Id} not found on GetEntityByIdQueryHandler");

            TViewModel entityViewModel;
            try
            {
                entityViewModel = MapEntityToViewModel(entity);
            }
            catch (Exception exception)
            {
                throw TemplateMathodException.Create(typeof(TEntity), typeof(GetEntityByIdQueryHandler<TEntity, TRepository, TQuery, TViewModel>), entity.Id, "MapEntityToViewModel", exception);
            }


            return CommandResult<TViewModel>.CommandFinished(entityViewModel!);
        }

        protected abstract TViewModel MapEntityToViewModel(TEntity entity);

        protected override EventType GetEventType() => EventType.Query;
    }
}
