using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : EntityDTO, IAppMessage<GetProductByIdViewModel>
    {
    }
}
