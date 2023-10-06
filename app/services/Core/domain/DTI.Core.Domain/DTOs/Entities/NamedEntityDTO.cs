namespace DTI.Core.Domain.DTOs.Entities
{
    public class NamedEntityDTO : EntityDTO
    {
        public NamedEntityDTO()
        { }
        public NamedEntityDTO(Guid id, string name) : base(id)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
