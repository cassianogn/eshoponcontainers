using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeGetEntityById;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity;
using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Controllers;
using Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Services;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeControllers
{
    internal class FakeController : EntityController<FakeGetEntityByIdQuery, FakeGetEntityByIdViewModel, FakeCreateEntityCommand, FakeUpdateEntityCommand, FakeDeleteEntityCommand>
    {
        public FakeController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest, busService)
        {
        }

        protected override HttpAuthParameters GetAuthParameters()
        {
            return HttpAuthParameters.GetAnonymousAuth();
        }

      
    }
}
