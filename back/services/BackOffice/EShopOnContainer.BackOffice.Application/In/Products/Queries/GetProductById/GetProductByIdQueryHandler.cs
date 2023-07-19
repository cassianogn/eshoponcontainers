using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects.DTOs;
using Cassiano.EShopOnContainers.Core.Application.In.Queries.GetEntityById;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : GetEntityByIdQueryHandler<Product, IProductRepository, GetProductByIdQuery, GetProductByIdViewModel>
    {
        public GetProductByIdQueryHandler(IMediator mediator, IProductRepository repository) : base(mediator, repository)
        {
        }

        protected override GetProductByIdViewModel MapEntityToViewModel(Product entity)
        {
            return new GetProductByIdViewModel
            {
                Id = entity.Id,
                Name = entity.Name.Value,
                Description = entity.Description,
                Enable = entity.Enable,
                EnableDate = entity.EnableDate,
                DisableDate = entity.DisableDate,
                Price = new ProductPriceDTO
                {
                    Cost = entity.Price.Cost,
                    Sale = entity.Price.Sale
                },
                ProductCategories = entity.ProductCategories.Select(productCategory => new NamedEntityDTO() { Id = productCategory.CategoryId, Name = productCategory.Category.Name.Value }),
                ProductColors = entity.ProductColors.Select(productColor => new ProductColorViewModel() { Id = productColor.ColorId, Name = productColor.Color.Name.Value, StockQuantity = productColor.StockQuantity })
            };
        }
    }
}
