using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.In.Tests.Products
{
    [TestCaseOrderer("EShopOnContainer.Catalog.Infra.In.Tests.Orders.PriorityOrderer", "EShopOnContainer.Catalog.Infra.In.Tests")]
    [Collection(nameof(CatalogProductCollection))]
    internal class CatalogProductTests
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
            //_fixture = fixture;
        }
    }
}
