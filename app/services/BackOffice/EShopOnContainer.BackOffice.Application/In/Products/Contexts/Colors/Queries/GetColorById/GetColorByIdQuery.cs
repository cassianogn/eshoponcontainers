using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.GetColorById
{
    public class GetColorByIdQuery : EntityDTO, IAppMessage<NamedEntityDTO>
    {
    }
}
