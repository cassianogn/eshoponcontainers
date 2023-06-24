using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity
{
    internal class AddEntityCommandHandler<TEntity> : BaseRequesHandler<AddEntityCommand, Guid>
    {
        public AddEntityCommandHandler(IMediator mediator) : base(mediator)
        {
        }

        public override Task<CommandResult<Guid>> ExecuteAsync(AddEntityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override EventType GetEventType()
        {
            throw new NotImplementedException();
        }

    }
}
