using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Search;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.SearchCategory
{
    public class SearchCategoryQuery : SearchQuery, IAppMessage<IEnumerable<NamedEntityDTO>>
    {
        public SearchCategoryQuery(string queryKey) : base(queryKey)
        {
        }
    }
}
