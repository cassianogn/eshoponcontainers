using DTI.Core.Application.In.Commands.DeleteEntity;
using DTI.Core.Application.Tests.Integration.Domain.FakieEntities;
using MediatR;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity
{
    internal class FakeDeleteEntityCommandHandler : DeleteEntityCommandHandler<FakeEntity, IFakeEntityRepository, FakeDeleteEntityCommand>
    {
        public FakeDeleteEntityCommandHandler(IMediator mediator, IFakeEntityRepository repository) : base(mediator, repository)
        {
        }
    }
}
