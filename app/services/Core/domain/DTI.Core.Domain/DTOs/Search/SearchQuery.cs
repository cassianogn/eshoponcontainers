using DTI.Core.Domain.Interfaces.DTOs;

namespace DTI.Core.Domain.DTOs.Search
{
    public class SearchQuery : IEntityDTO
    { 
        public Guid Id { get; set; } = Guid.NewGuid();
        public string QueryKey { get; set; }

    }
}
