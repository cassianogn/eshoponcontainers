using Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using MediatR;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity
{
    internal class FakeCreateEntityCommandHandler : AddEntityCommandHandler<FakeEntity, IFakeEntityRepository, FakeCreateEntityCommand>
    {
        public FakeCreateEntityCommandHandler(IMediator mediator, IFakeEntityRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
           
        }

        protected override FakeEntity ParseCommandToEntity(FakeCreateEntityCommand request)
        {
            return new FakeEntity(Guid.NewGuid(), request.Name, request.Description);
        }

    }
}
