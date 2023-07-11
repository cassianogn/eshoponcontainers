using Cassiano.EShopOnContainers.Core.Application.In.Commands.UpdateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity
{
    internal class FakeUpdateEntityCommandHandler : UpdateEntityCommandHandler<FakeEntity, IFakeEntityRepository, FakeUpdateEntityCommand>
    {
        public FakeUpdateEntityCommandHandler(IMediator mediator, IFakeEntityRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
        }

        protected override void SetUpdateDataInEntity(FakeEntity entity, FakeUpdateEntityCommand request) => entity.Update(request.Name, request.Description);
    }
}
