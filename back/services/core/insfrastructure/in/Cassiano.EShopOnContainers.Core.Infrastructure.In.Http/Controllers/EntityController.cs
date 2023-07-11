using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Microsoft.AspNetCore.Mvc;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Controllers
{
    public abstract class EntityController<TGetByIdQuery, TGetByIdViewModel, TAddCommand, TUpdateCommand, TDeleteCommand> : CoreController
        where TGetByIdQuery : class, IEntityDTO, IAppMessage<TGetByIdViewModel>, new()
        where TAddCommand : class, IEntityDTO, IAppMessage<Guid?>
        where TUpdateCommand : class, IEntityDTO, IAppMessage
        where TDeleteCommand : class, IEntityDTO, IAppMessage, new()
    {
        protected readonly BusService BusService;
        protected EntityController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest)
        {
            BusService = busService;
        }

        [HttpGet("${id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var query = new TGetByIdQuery() { Id = id };
            var queryResult = await BusService.SendMessage<TGetByIdQuery, TGetByIdViewModel>(query);
            return ResponseCareErrors(() => Ok(queryResult.Result));
        }
        
        [HttpPost]
        public virtual async Task<IActionResult> AddAsync(TAddCommand command)
        {
            var commandResult = await BusService.SendMessage<TAddCommand, Guid?>(command);
            return ResponseCareErrors(() => Created("", new { Id = commandResult.Result!.Value }));
        }
        [HttpPut("${id}")]
        public virtual async Task<IActionResult> UpdateAsync(Guid id, TUpdateCommand command)
        {
            if (id != command.Id)
                return BadRequest($"The provided id by URL don't is equal as DTO. the url: {id}, DTO: {command.Id}");

            await BusService.SendMessage(command);
            return ResponseCareErrors(NoContent);
        }

        [HttpDelete("${id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            var command = new TDeleteCommand() { Id = id };
            await BusService.SendMessage(command);
            return ResponseCareErrors(NoContent);
        }

    }
}
