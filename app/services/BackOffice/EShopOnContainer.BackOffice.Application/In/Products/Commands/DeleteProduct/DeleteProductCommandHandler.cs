using EShopOnContainer.BackOffice.Domain.Products;
using DTI.Core.Application.In.Commands.DeleteEntity;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : DeleteEntityCommandHandler<Product, IProductRepository, DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IMediator mediator, IProductRepository repository) : base(mediator, repository)
        {
        }
    }
}
