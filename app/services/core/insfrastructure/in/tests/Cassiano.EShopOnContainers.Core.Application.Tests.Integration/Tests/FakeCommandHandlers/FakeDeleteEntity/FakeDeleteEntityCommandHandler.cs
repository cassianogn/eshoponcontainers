using Cassiano.EShopOnContainers.Core.Application.In.Commands.DeleteEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity
{
    internal class FakeDeleteEntityCommandHandler : DeleteEntityCommandHandler<FakeEntity, IFakeEntityRepository, FakeDeleteEntityCommand>
    {
        public FakeDeleteEntityCommandHandler(IMediator mediator, IFakeEntityRepository repository) : base(mediator, repository)
        {
        }
    }
}
