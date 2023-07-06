using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeDeleteEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeGetEntityById;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeUpdateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.Fakes;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.Tests
{
    public class EntityCrudCommandHandlerTest
    {
        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;

        public EntityCrudCommandHandlerTest()
        {
            var services = new ServiceCollection();

            services.AddCoreApplication<FakeInfrastructureBus>(new List<Assembly>() { typeof(EntityCrudCommandHandlerTest).Assembly });
            services.AddScoped<IFakeEntityRepository, FakeEntityRepository>();
            var providers = services.BuildServiceProvider();

            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
        }

        [Trait("Categoria", "BaseCommandHandler")]
        [Fact(DisplayName = "1 - AddEntity Success")]
        public async Task CreateEntityComandHandler_NewEntity_Success()
        {
            var command = new FakeCreateEntityCommand()
            {
                Name = "test",
                Description = "test"
            };
            var commandResult = await _bus.SendMessage<FakeCreateEntityCommand, Guid?>(command);
            Assert.NotNull(commandResult.Result);
            Assert.NotEqual(Guid.Empty, commandResult.Result);
            Assert.False(HasNotifications());
        }

        [Trait("Categoria", "BaseCommandHandler")]
        [Fact(DisplayName = "2 - AddEntity with domain error")]
        public async Task CreateEntityComandHandler_NewEntity_Fail()
        {
            var command = new FakeCreateEntityCommand()
            {
                Name = "test",
            };
            var commandResult = await _bus.SendMessage<FakeCreateEntityCommand, Guid?>(command);
            Assert.Null(commandResult.Result);
            Assert.True(HasNotifications());
        }

        [Trait("Categoria", "BaseCommandHandler")]
        [Fact(DisplayName = "3 - Update entity")]
        public async Task UpdateEntityComandHandler_SuccessAsync()
        {
            // arange
            var fakeEntityDTO = new FakeUpdateEntityCommand()
            {
                Id = Guid.NewGuid(),
                Name = "cassiano editado",
                Description = "cassiano editado"
            };
            //act
            var commandResult = await _bus.SendMessage(fakeEntityDTO);

            // assert
            Assert.True(commandResult.ProccessCompleted);
            Assert.False(HasNotifications());
        }

        //unit test to class FakeEntity



        [Trait("Categoria", "BaseCommandHandler")]
        [Fact(DisplayName = "4 - Delete entity")]
        public async Task DeleteEntityComandHandler_SuccessAsync()
        {
            // arange
            var fakeEntityDTO = new FakeDeleteEntityCommand()
            {
                Id = Guid.NewGuid()
            };

            //act
            var commandResult = await _bus.SendMessage(fakeEntityDTO);

            // assert
            Assert.True(commandResult.ProccessCompleted);
            Assert.False(HasNotifications());
        }
        [Trait("Categoria", "BaseCommandHandler")]
        [Fact(DisplayName = "5 - Get entity by id")]
        public async Task DeleteEntityComandHandler_NewEntity_SuccessAsync()
        {
            // arange
            var fakeEntityDTO = new FakeGetEntityByIdQuery()
            {
                Id = Guid.NewGuid()
            };

            //act
            var commandResult = await _bus.SendMessage<FakeGetEntityByIdQuery, FakeGetEntityByIdViewModel?>(fakeEntityDTO);

            // assert
            Assert.True(commandResult.ProccessCompleted);
        }


        private IEnumerable<Notification> GetNotifications()
        {
            return _domainNotificationService.GetAll().Where(notification => notification.Code != "testinfra");
        }
        private bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        private static IServiceProvider GetScope()
        {
            //var serviceProvider = new ServiceProvider(,);

            // TODO: ADD dependecy

            //return serviceCollection;        
            return null;
        }
    }
}
