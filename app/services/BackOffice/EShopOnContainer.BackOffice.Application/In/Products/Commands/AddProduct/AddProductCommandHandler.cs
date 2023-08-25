using EShopOnContainer.BackOffice.Domain.Products;
using EShopOnContainer.BackOffice.Domain.Products.SubEntities;
using DTI.Core.Application.In.Commands.AddEntity;
using DTI.Core.Domain.Services.DomainNotifications;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.AddProduct
{
    internal class AddProductCommandHandler : AddEntityCommandHandler<Product, IProductRepository, AddProductCommand>
    {
        public AddProductCommandHandler(IMediator mediator, IProductRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
        }

        protected override Product ParseCommandToEntity(AddProductCommand request)
        {
            return new Product(request.Id,
                request.Name,
                request.Price,
                request.Enable,
                request.Description,
                request.ProductCategories.Select(categoryDTO => new ProductCategory(Guid.NewGuid(), request.Id, categoryDTO.Id)).ToList(),
                request.ProductColors.Select(colorDTO => new ProductColor(Guid.NewGuid(), request.Id, colorDTO.Id, colorDTO.StockQuantity)).ToList()
                );
        }

    }
}
