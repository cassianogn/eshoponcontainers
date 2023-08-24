using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Search;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.SearchColor
{
    public class SearchColorQuery : SearchQuery, IAppMessage<IEnumerable<NamedEntityDTO>>
    {
    }
}
