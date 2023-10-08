using DTI.Core.Domain.Auth;
using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.Interfaces.DTOs;
using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.Bus.Interfaces;
using DTI.Core.Domain.Services.DomainNotifications;
using Microsoft.AspNetCore.Mvc;

namespace DTI.Core.Infra.In.Http.Controllers
{
    public abstract class NamedEntityController<TGetByIdQuery, TGetByIdViewModel, TSearchEntityQuery, TSearchEntityViewModel, TAddCommand, TUpdateCommand, TDeleteCommand> : EntityController<TGetByIdQuery, TGetByIdViewModel, TAddCommand, TUpdateCommand, TDeleteCommand>
        where TGetByIdQuery : class, IEntityDTO, IAppMessage<TGetByIdViewModel>,new()
        where TSearchEntityQuery : SearchQuery, IAppMessage<IEnumerable<TSearchEntityViewModel>>,new()
        where TAddCommand : class, IEntityDTO, IAppMessage<Guid?>
        where TUpdateCommand : class, IEntityDTO, IAppMessage
        where TDeleteCommand : class, IEntityDTO, IAppMessage, new()
    {
        protected NamedEntityController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest, busService)
        {
        }

        [HttpGet]
        public virtual async Task<IActionResult> Search([FromQuery] TSearchEntityQuery query)
        {
            var queryResult = await BusService.SendMessage<TSearchEntityQuery, IEnumerable<TSearchEntityViewModel>>(query);
            return ResponseCareErrors(() => Ok(queryResult.Result));
        }
    }
}
