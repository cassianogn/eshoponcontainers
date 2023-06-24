using Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity
{
    internal class FakeCreateEntityCommandHandler : AddEntityCommandHandler<FakeEntity, IFakeEntityRepository, FakeCreateEntityCommand>
    {
        public FakeCreateEntityCommandHandler(IMediator mediator) : base(mediator)
        {
        }

        public override Task<CommandResult<Guid>> ExecuteAsync(FakeCreateEntityCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(CommandResult<Guid>.GetSuccess(Guid.Empty));
        }

        protected override EventType GetEventType() => EventType.Create;
    }
}
