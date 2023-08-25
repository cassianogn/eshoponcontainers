using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : EntityDTO, IAppMessage<GetProductByIdViewModel>
    {
    }
}
