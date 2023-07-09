using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Controllers
{
    public abstract class EntityController<TGetByIdQuery, TGetByIdViewModel, TAddCommand> : CoreController
        where TGetByIdQuery : class, IEntityDTO, IAppMessage<TGetByIdViewModel>
        where TAddCommand : class, IEntityDTO, IAppMessage<Guid?>
    {
        protected EntityController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest) : base(domainNotificationService, usuarioHttpRequest)
        {
        }
    }
}
