using Cassiano.EShopOnContainers.Core.Application;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.FakesInfra;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithoutReturn;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithReturn;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Events.TestBusMemoryWithReturn;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestInfrastructureBus;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestInfrastructureBus.Commands;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestInfrastructureBus.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus
{
    public class BusTests
    {
        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;

        public BusTests()
        {
            var services = new ServiceCollection();

            services.AddCoreApplication(new List<Assembly>() { typeof(BusTests).Assembly }, service => new InfrastructureBus(service.GetRequiredService<DomainNotificationService>()));

            var providers = services.BuildServiceProvider();

            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
        }
        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "1 - Publish Memory Event")]
        public async Task PublishMemoryEventAsync()
        {
            await _bus.PublishEvent(new TestBusMemoryWithReturnEvent());

            var hasFirstExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "test1");
            var hasSecondExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "test2");
            var notRunExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "error");

            Assert.NotNull(hasFirstExecution);
            Assert.NotNull(hasSecondExecution);
            Assert.Null(notRunExecution);
        }

        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "2 - Send Without Return Memory Message")]
        public async Task SendWithoutReturnMemoryMessageAsync()
        {
            var result = await _bus.SendMessage(new TestBusMemoryWithoutReturnCommand());

            var hasFirstExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "test");

            Assert.True(result.ProccessCompleted);
            Assert.NotNull(hasFirstExecution);

        }
        
        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "3 - Send Without Return Memory Message with error")]
        public async Task SendWithoutReturnMemoryMessageWithErrorAsync()
        {
            try
            {
                await _bus.SendMessage(new TestBusMemoryWithoutReturnCommand() { ThrowError = true });
            }
            catch (Exception error)
            {
                Assert.Equal("Error on execute command", error.Message);
                Assert.Equal("Expected Error", error.InnerException!.Message);
            } 
            

        }
        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "3 - Send With Return Memory Message ")]
        public async Task SendWithReturnMemoryMessage()
        {
            var result = await _bus.SendMessage<TestBusMemoryWithReturnCommand, Guid>(new TestBusMemoryWithReturnCommand());

            var hasFirstExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "test");

            Assert.True(result.ProccessCompleted);
            Assert.NotNull(hasFirstExecution);
        }

        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "4 - Publish Infrastructure Event")]
        public async Task PublishInfrastructureEvent()
        {
            await _bus.PublishEvent(new TestBusEvent(), BusTransactionType.Infrastructure, default);

            var hasFirstExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "testinfra");
            Assert.NotNull(hasFirstExecution);
        }

        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "5 - Send Without Return Infrastructure Message")]
        public async Task SendWithoutReturnInfrastructureMessage()
        {
            var result = await _bus.SendMessage(new TestBusInfraWithoutReturnCommand(), BusTransactionType.Infrastructure, default);

            var hasFirstExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "testinfra");

            Assert.True(result.ProccessCompleted);
            Assert.NotNull(hasFirstExecution);
        }

        [Trait("Categoria", "Bus")]
        [Fact(DisplayName = "6 - Send With Return Infrastructure Message")]
        public async Task SendWithReturnInfrastructureMessage()
        {
            var result = await _bus.SendMessage<TestBusInfraWithReturnCommand, Guid>(new TestBusInfraWithReturnCommand(), BusTransactionType.Infrastructure, default);

            var hasFirstExecution = _domainNotificationService.GetAll().FirstOrDefault(notification => notification.Code == "testinfra");

            Assert.True(result.ProccessCompleted);
            Assert.NotNull(hasFirstExecution);
        }

    }
}
