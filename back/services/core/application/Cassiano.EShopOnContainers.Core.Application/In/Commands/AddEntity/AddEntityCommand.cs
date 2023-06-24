using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity
{
    public class AddEntityCommand : NamedEntityDTO, IAppMessage<Guid>
    {

    }
}
