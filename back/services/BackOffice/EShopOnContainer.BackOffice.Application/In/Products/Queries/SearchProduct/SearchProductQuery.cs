using Cassiano.EShopOnContainers.Core.Domain.DTOs.Search;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.SearchProduct
{
    public class SearchProductQuery : SearchQuery, IAppMessage<IEnumerable<SearchProductViewModel>>
    {
      
    }
}
