using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.AddColor
{
    public class AddColorCommand : NamedEntityDTO, IAppMessage<Guid?>
    {
    }
}
