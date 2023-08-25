using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.AddColor
{
    public class AddColorCommand : NamedEntityDTO, IAppMessage<Guid?>
    {
    }
}
