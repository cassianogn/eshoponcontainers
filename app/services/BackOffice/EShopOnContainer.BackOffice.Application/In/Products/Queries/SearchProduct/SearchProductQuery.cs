using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.SearchProduct
{
    public class SearchProductQuery : SearchQuery, IAppMessage<IEnumerable<SearchProductViewModel>>
    {
      
    }
}
