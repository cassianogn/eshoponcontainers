using DTI.Core.Domain.Interfaces.DTOs;

namespace DTI.Core.Domain.DTOs.Entities
{
    public class EntityDTO: IEntityDTO
    {
        public Guid Id { get; set; }
    }
}
