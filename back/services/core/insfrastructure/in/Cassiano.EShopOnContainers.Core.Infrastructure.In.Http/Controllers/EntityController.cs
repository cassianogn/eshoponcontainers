using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Microsoft.AspNetCore.Mvc;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Controllers
{
    public abstract class EntityController<TGetByIdQuery, TGetByIdViewModel, TAddCommand> : CoreController
        where TGetByIdQuery : class, IEntityDTO, IAppMessage<TGetByIdViewModel>
        where TAddCommand : class, IEntityDTO, IAppMessage<Guid?>
    {
        protected readonly BusService BusService;
        protected EntityController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest)
        {
            BusService = busService;
        }

        public virtual IActionResult Add(TAddCommand command)
        {
            var commandResult = BusService.SendMessage<TAddCommand, Guid?>(command);
            return ResponseCareErrors(() => Ok(commandResult.Result));
        }
    }
}
