using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Core;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.FakeControllers
{

    [TestCaseOrderer("Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Configs.Orders.PriorityOrderer", "Cassiano.EShopOnContainers.Core.Application.Tests.Integration")]
    [Collection(nameof(FakeControllerCollection))]
    public class FakeControllerTests
    {

        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;
        private readonly FakeEntityHandlerFixture _fixture;
        private readonly IFakeEntityRepository _repository;
        

        public FakeControllerTests(FakeEntityHandlerFixture fixture)
        {

            var providers = TestsServiceProvider.GetServiceProvider();
            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
            _repository = providers.GetRequiredService<IFakeEntityRepository>();
            _fixture = fixture;
        }
    }
}
