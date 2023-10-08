using DTI.Core.Domain.Services.Bus.Interfaces;
using EShopOnContainer.Catalog.Application.Products.Entities;

namespace EShopOnContainer.Catalog.Application.Products.UseCases.Commands.AddProduct
{
    public class AddProductCommand : ProductModel, IAppMessage
    {
    }
}
