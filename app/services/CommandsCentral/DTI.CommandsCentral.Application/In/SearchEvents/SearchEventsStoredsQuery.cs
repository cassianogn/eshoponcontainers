using DTI.CommandsCentral.Domain.EventSourcing.DTOs;
using MediatR;

namespace DTI.CommandsCentral.Application.In.SearchEvents
{
    public class SearchEventsStoredsQuery : SearchEventsStoredsDTO, IRequest<IEnumerable<SearchEventsStoredsViewModel>>
    {
        
    }
}
