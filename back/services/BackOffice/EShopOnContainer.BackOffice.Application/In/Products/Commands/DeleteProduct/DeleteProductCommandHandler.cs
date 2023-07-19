using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using Cassiano.EShopOnContainers.Core.Application.In.Commands.DeleteEntity;
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
