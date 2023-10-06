using DTI.Core.Domain.Interfaces.DTOs;

namespace DTI.Core.Domain.DTOs.Entities
{
    public class EntityDTO: IEntityDTO
    {
        public EntityDTO() { }
        public EntityDTO(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
