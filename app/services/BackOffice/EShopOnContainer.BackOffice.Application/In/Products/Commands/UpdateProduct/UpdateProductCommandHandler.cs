using EShopOnContainer.BackOffice.Domain.Products;
using EShopOnContainer.BackOffice.Domain.Products.SubEntities;
using DTI.Core.Application.In.Commands.UpdateEntity;
using DTI.Core.Domain.Services.DomainNotifications;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : UpdateEntityCommandHandler<Product, IProductRepository, UpdateProductCommand>
    {
        public UpdateProductCommandHandler(IMediator mediator, IProductRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
        }

        protected override void SetUpdateDataInEntity(Product entity, UpdateProductCommand request)
        {
            entity.UpdateFormData(
                request.Name,
                request.Price,
                request.Description,
                request.ProductCategories.Select(categoryDTO => new ProductCategory(Guid.NewGuid(), request.Id, categoryDTO.Id)).ToList(),
                request.ProductColors.Select(colorDTO => new ProductColor(Guid.NewGuid(), request.Id, colorDTO.Id, colorDTO.StockQuantity)).ToList()
                );

        }
    }
}
