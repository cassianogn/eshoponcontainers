using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;

namespace Cassiano.EShopOnContainers.Core.Domain.DTOs.Search
{
    public class SearchQuery : IEntityDTO
    {

        public SearchQuery(string queryKey)
        {
            QueryKey = queryKey;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string QueryKey { get; set; }

    }
}
