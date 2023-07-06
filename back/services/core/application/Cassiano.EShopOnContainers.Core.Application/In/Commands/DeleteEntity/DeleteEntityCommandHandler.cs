using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.DeleteEntity
{
    public abstract class DeleteEntityCommandHandler<TEntity, TRepository, TDeleteCommand> : BaseRequestHandler<TDeleteCommand>
        where TEntity : IEntityWithDomainValidations<TEntity>
        where TRepository : IWriterRepository<TEntity>
        where TDeleteCommand : IEntityDTO, IAppMessage
    {
        protected readonly TRepository Repository;

        protected DeleteEntityCommandHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            Repository = repository;
        }

        protected override EventType GetEventType() => EventType.Delete;
        public override async Task<CommandResult> ExecuteAsync(TDeleteCommand request, CancellationToken cancellationToken)
        {
            await BeforeDeleteTemplateMethod(request, cancellationToken);
            await Repository.DeleteAsync(request.Id, cancellationToken);
            await AfterDeleteEntityTemplateMethod(request, cancellationToken);

            return CommandResult.CommandFinished();
        }

        protected virtual Task BeforeDeleteTemplateMethod(TDeleteCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        protected virtual Task AfterDeleteEntityTemplateMethod(TDeleteCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
