using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity
{
    public class AddEntityCommandHandler<TEntity, TRepository, TAddCommand> : BaseRequesHandler<TAddCommand, Guid> 
        where TEntity : IEntity
        where TRepository : IWriterRepository<TEntity>
        where TAddCommand : AddEntityCommand

    {

        public AddEntityCommandHandler(IMediator mediator) : base(mediator)
        {
        }

        public override Task<CommandResult<Guid>> ExecuteAsync(TAddCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override EventType GetEventType()
        {
            throw new NotImplementedException();
        }
    }
}
