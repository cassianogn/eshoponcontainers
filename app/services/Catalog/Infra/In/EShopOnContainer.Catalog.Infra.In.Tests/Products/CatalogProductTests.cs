using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.In.Tests.Products
{
    //[TestCaseOrderer("DTI.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders.PriorityOrderer", "DTI.Core.Application.Tests.Integration")]
    //[Collection(nameof(FakeEntityHandlerCollection))]
    internal class CatalogProductTests
    {
        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;

        //public CatalogProductTests(FakeEntityHandlerFixture fixture)
        public CatalogProductTests()
        {
            var providers = new TestServiceProvider().ServiceProvider;

            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
            //_repository = providers.GetRequiredService<IProductRepository>();
            //_fixture = fixture;
        }
    }
}
