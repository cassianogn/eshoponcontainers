using DTI.Core.Domain.Services.Bus.Interfaces;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.Shared;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.AddProduct
{
    public class AddProductCommand : BaseProductDTO, IAppMessage<Guid?>
    {
        public bool Enable { get; set; }

    }
}
