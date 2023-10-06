using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.Catalog.Application.Products.UseCases.Queries.SearchProduct
{
    public class SearchProductQuery : IAppMessage<IEnumerable<SearchProductViewModel>>
    {
        public string SearchKey { get; set; }
    }
}
