using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : EntityDTO, IAppMessage<NamedEntityDTO>
    {
    }
}
