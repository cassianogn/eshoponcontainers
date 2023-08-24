using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing.DTOs;
using MediatR;

namespace Cassiano.EShopOnContainers.CommandsCentral.Application.In.SearchEvents
{
    public class SearchEventsStoredsQuery : SearchEventsStoredsDTO, IRequest<IEnumerable<SearchEventsStoredsViewModel>>
    {
        
    }
}
