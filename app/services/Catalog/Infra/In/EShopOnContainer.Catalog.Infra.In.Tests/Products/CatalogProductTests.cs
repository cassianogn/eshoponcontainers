using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using EShopOnContainer.Catalog.Application.Products.UseCases.Commands.AddProduct;
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

        public CatalogProductTests(CatalogProductCollection fixture)
        {
            var providers = new TestServiceProvider().ServiceProvider;

            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
            _repository = providers.GetRequiredService<IProductRepository>();
        }

        [Trait("Category", "4 - Catalogy"), TestPriority(4.1)]
        [Fact(DisplayName = "1 - AddEntity Success")]
        public async Task CreateEntityComandHandler_NewEntity_Success()
        {
            var command = new AddProductCommand()
            {
                Name = "test",
                Description = "test"
            };
            var commandResult = await _bus.SendMessage(command);
            Assert.NotNull(commandResult);

        }
    }
}
