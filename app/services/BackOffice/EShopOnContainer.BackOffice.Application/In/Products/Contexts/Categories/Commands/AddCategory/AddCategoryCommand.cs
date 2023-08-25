using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : NamedEntityDTO, IAppMessage<Guid?>
    {
    }
}
