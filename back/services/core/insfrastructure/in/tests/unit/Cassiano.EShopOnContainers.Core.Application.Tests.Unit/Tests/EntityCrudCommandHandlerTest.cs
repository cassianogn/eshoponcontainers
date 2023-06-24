using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.Fakes;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

            var providers = services.BuildServiceProvider();

            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
        }
        [Fact]
        public async Task CreateEntityComandHandler_NewEntity_SuccessAsync()
        {
            await _bus.SendMessage<Guid>(new FakeCreateEntityCommand()
            {
                Name = "cassiano"
            });
        }
        //[Fact(DisplayName = "Update entity")]
        //public async Task DeleteEntityComandHandler_NewEntity_SuccessAsync()
        //{
        //    // arange
        //    var scope = GetScope();
        //    var domainNotification = scope.GetRequiredService<DomainNotificationService>;
        //    var handler = scope.GetRequiredService<FakeUpdateEntityCommandHandler>;
        //    var fakeEntityDTO = new FakeUpdateEntityCommand()
        //    {
        //        EntityId = handleEntity.Id
        //        Name = "cassiano editado"
        //    };
        //handleEntity.Name = fakeEntityDTO.Name;
        //    //act
        //    await handler.ExecuteAsync(fakeEntityDTO);

        //    // assert
        //    Assert.NotEmpty(domainNotification.Notifications);
        //}

        //[Fact(DisplayName = "get entity by id")]
        //    public async Task DeleteEntityComandHandler_NewEntity_SuccessAsync()
        //    {
        //        // arange
        //        var scope = GetScope();
        //        var domainNotification = scope.GetRequiredService<DomainNotificationService>;
        //        var handler = scope.GetRequiredService<FakeGetEntityByIdQueryHandler>;
        //        var fakeEntityDTO = new FakeGetEntityByIdQuery()
        //        {
        //            EntityId = handleEntity.Id
        //        };

        //        //act
        //        var searchedEntity = await handler.ExecuteAsync(fakeEntityDTO);


        //        // assert
        //        Assert.Equal(searchedEntity.Id, fakeEntityDTO.EntityId);
        //        Assert.Equal(searchedEntity.Name, handleEntity.Name);
        //    }


        //[Fact(DisplayName = "Delete entity")]
        //public async Task DeleteEntityComandHandler_NewEntity_SuccessAsync()
        //{
        //    // arange
        //    var scope = GetScope();
        //    var domainNotification = scope.GetRequiredService<DomainNotificationService>;
        //    var handler = scope.GetRequiredService<FakeDeleteEntityCommandHandler>;
        //    var fakeEntityDTO = new FakeDeleteEntityCommand()
        //    {
        //        EntityId = handleEntity.Id
        //    };

        //    //act
        //    await handler.ExecuteAsync(fakeEntityDTO);

        //    // assert
        //    Assert.NotEmpty(domainNotification.Notifications);
        //}


        private static IServiceProvider GetScope()
        {
            //var serviceProvider = new ServiceProvider(,);

            // TODO: ADD dependecy

            //return serviceCollection;        
            return null;
        }
    }
}
