using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.SearchColor
{
    public class SearchColorQuery : SearchQuery, IAppMessage<IEnumerable<NamedEntityDTO>>
    {
    }
}
