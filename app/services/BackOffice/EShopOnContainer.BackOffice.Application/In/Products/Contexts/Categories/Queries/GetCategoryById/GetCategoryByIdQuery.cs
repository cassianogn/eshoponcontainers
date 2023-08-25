using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : EntityDTO, IAppMessage<NamedEntityDTO>
    {
    }
}
