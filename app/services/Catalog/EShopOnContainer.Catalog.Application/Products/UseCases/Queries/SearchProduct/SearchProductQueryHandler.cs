using DTI.Core.Domain.EventSourcing;
using DTI.Core.Domain.Services.Bus.Bases;
using DTI.Core.Domain.Services.Bus.Models;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using MediatR;

namespace EShopOnContainer.Catalog.Application.Products.UseCases.Queries.SearchProduct
{
    internal class SearchProductQueryHandler : BaseRequestHandler<SearchProductQuery, IEnumerable<SearchProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public SearchProductQueryHandler(IMediator mediator, IProductRepository productRepository) : base(mediator)
        {
            _productRepository = productRepository;
        }

        public override async Task<CommandResult<IEnumerable<SearchProductViewModel>>> ExecuteAsync(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var productsDb = await _productRepository.Search(1, request.SearchKey);
            var productsViewModel = productsDb.Select(productDb => new SearchProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Description = productDb.Description,
                Price = productDb.Price
            }).ToList();
            return CommandResult<IEnumerable<SearchProductViewModel>>.CommandFinished(productsViewModel);
        }

        protected override EventType GetEventType() => EventType.Query;
    }
}
