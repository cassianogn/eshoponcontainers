using Cassiano.EShopOnContainers.Core.Application.In.Commands.DeleteEntity;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeDeleteEntity
{
    internal class FakeDeleteEntityCommandHandler : DeleteEntityCommandHandler<FakeEntity, IFakeEntityRepository, FakeDeleteEntityCommand>
    {
        public FakeDeleteEntityCommandHandler(IMediator mediator, IFakeEntityRepository repository) : base(mediator, repository)
        {
        }
    }
}
