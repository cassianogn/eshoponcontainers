using DTI.CommandsCentral.Domain.EventSourcing;
using DTI.CommandsCentral.Domain.EventSourcing.DTOs;
using MediatR;

namespace DTI.CommandsCentral.Application.In.SearchEvents
{
    public class SearchEventsStoredsQueryHandler : IRequestHandler<SearchEventsStoredsQuery, IEnumerable<SearchEventsStoredsViewModel>>
    {
        private readonly IEventStoredRepository _eventStoredRepository;
        public SearchEventsStoredsQueryHandler(IEventStoredRepository eventStoredRepository)
        {
            _eventStoredRepository = eventStoredRepository;
        }
        public async Task<IEnumerable<SearchEventsStoredsViewModel>> Handle(SearchEventsStoredsQuery request, CancellationToken cancellationToken)
        {
            var result = await _eventStoredRepository.SeachAsync(request);
            return result.Select(eventStored => new SearchEventsStoredsViewModel
            {
                Id = eventStored.Id,
                EntityId = eventStored.EntityId,
                JsonCommand = eventStored.JsonCommand,
                CommandTypeOf = eventStored.CommandTypeOf,
                Date = eventStored.Date,
                Type = eventStored.Type,
                Success = eventStored.Success,
                FullException = eventStored.FullException,
                MessageException = eventStored.MessageException
            });
        }
    }
}
