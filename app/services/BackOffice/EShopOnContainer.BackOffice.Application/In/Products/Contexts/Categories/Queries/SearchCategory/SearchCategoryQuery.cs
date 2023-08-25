using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.SearchCategory
{
    public class SearchCategoryQuery : SearchQuery, IAppMessage<IEnumerable<NamedEntityDTO>>
    {
     
    }
}
