namespace Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing.DTOs
{
    public class SearchEventsStoredsDTO
    {
        public Guid? EventId { get; set; }
        public Guid? EntityId { get; set; }
        public bool? Success { get; set; }
        public string? Body { get; set; }
        public string? CommandType { get; set; }
        public int? LimitOfResult { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
