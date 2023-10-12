using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using EShopOnContainer.Catalog.Application.Products.UseCases.Commands.AddProduct;
using EShopOnContainer.Catalog.Application.Products.UseCases.Queries.SearchProduct;
using EShopOnContainer.Catalog.Infra.In.Tests.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.In.Tests.Products
{
    [TestCaseOrderer("EShopOnContainer.Catalog.Infra.In.Tests.Orders.PriorityOrderer", "EShopOnContainer.Catalog.Infra.In.Tests")]
    [Collection(nameof(CatalogProductCollection))]
    public class CatalogProductTests
    {
        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;
        private readonly IProductRepository _repository;
        private readonly CatalogProductFixture _fixture;

        public CatalogProductTests(CatalogProductFixture fixture)
        {
            var providers = new TestServiceProvider().ServiceProvider;

            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
            _repository = providers.GetRequiredService<IProductRepository>();
            _fixture = fixture;
        }

        [Trait("Category", "4 - Catalogy"), TestPriority(4.1)]
        [Fact(DisplayName = "1 - AddEntity Success")]
        public async Task CreateEntityComandHandler_NewEntity_Success()
        {
            var command = new AddProductCommand()
            {
                Name = "test " + DateTime.UtcNow,
                Description = "test"
            };
            var commandResult = await _bus.SendMessage(command);

            _fixture.Product = (await _repository.GetById(command.Id))!;
            //Assert.NotNull(commandResult);
        }


        [Trait("Category", "4 - Catalogy"), TestPriority(4.2)]
        [Fact(DisplayName = "2 - Get Product Success")]
        public async Task GetEntityComandHandler_Success()
        {
            var query = new SearchProductQuery()
            {
                SearchKey = _fixture.Product.Name
            };
            var queryResult = await _bus.SendMessage<SearchProductQuery, IEnumerable<SearchProductViewModel>>(query);

            // queryResult.result should have only one item
            Assert.NotNull(queryResult);
            Assert.True(queryResult.Result.Count() == 1);


        }

    }
}
