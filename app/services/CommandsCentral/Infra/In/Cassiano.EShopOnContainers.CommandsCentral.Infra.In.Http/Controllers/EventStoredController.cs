using Cassiano.EShopOnContainers.CommandsCentral.Application.In.SearchEvents;
using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing;
using Microsoft.AspNetCore.Mvc;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.In.Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventStoredController : ControllerBase
    {
        private readonly IEventStoredRepository _eventStoredRepository;

        public EventStoredController(IEventStoredRepository eventStoredRepository)
        {
            _eventStoredRepository = eventStoredRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchEventsStoredsQuery query)
        {
            var result = await _eventStoredRepository.SeachAsync(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _eventStoredRepository.GetByIdAsync(id);
            return Ok(result);
        }

    }
}
