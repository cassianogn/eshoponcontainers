using EShopOnContainer.BackOffice.Domain.Products;
using DTI.Core.Application.In.Queries.SearchNamedEntity;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.SearchProduct
{
    internal class SearchProductQueryHandler : SearchNamedEntityQueryHandler<Product, IProductRepository, SearchProductQuery, SearchProductViewModel>
    {
        public SearchProductQueryHandler(IMediator mediator, IProductRepository repository) : base(mediator, repository)
        {
        }

    }
}
