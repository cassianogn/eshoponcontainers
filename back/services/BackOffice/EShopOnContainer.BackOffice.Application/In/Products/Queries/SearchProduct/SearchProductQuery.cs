using Cassiano.EShopOnContainers.Core.Domain.DTOs.Search;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.SearchProduct
{
    public class SearchProductQuery : SearchQuery, IAppMessage<IEnumerable<SearchProductViewModel>>
    {
        public SearchProductQuery(string queryKey) : base(queryKey)
        {
        }
    }
}
