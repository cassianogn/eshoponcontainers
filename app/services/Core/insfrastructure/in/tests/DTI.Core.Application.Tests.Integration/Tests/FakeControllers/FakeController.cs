using DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity;
using DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity;
using DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeGetEntityById;
using DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity;
using DTI.Core.Domain.Auth;
using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using DTI.Core.Infrastructure.In.Http.Controllers;
using DTI.Core.Infrastructure.In.Http.Services;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeControllers
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
