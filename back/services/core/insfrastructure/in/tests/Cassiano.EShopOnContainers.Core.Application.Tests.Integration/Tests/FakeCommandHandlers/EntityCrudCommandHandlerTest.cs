using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.FakesInfra;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.IoC;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeGetEntityById;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity;
using Cassiano.EShopOnContainers.Core.Domain.Helpers.Exceptions;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers
{
    [TestCaseOrderer("Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders.PriorityOrderer", "Cassiano.EShopOnContainers.Core.Application.Tests.Integration")]
    [Collection(nameof(FakeEntityHandlerCollection))]
    public class EntityCrudCommandHandlerTest
    {
        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;
        private readonly FakeEntityHandlerFixture _fixture;
        private readonly IFakeEntityRepository _repository;

        public EntityCrudCommandHandlerTest(FakeEntityHandlerFixture fixture)
        {

            var providers = TestsServiceProvider.GetServiceProvider(service => new FakeInfrastructureBus(service.GetRequiredService<DomainNotificationService>()));
            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
            _repository = providers.GetRequiredService<IFakeEntityRepository>();
            _fixture = fixture;
        }

        [Trait("Category", "1 - BaseCommandHandler"), TestPriority(1.1)]
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

            var addedEntity = await _repository.GetByIdAsync(commandResult.Result!.Value);
            _fixture.AddFakeEntity(addedEntity!);
        }

        [Trait("Category", "1 - BaseCommandHandler")]
        [Fact(DisplayName = "2 - AddEntity with domain error"), TestPriority(1.2)]
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
        [Trait("Category", "1 - BaseCommandHandler")]
        [Fact(DisplayName = "3 - Get entity by id"), TestPriority(1.3)]
        public async Task DeleteEntityComandHandler_NewEntity_SuccessAsync()
        {
            // arange
            var fakeEntityDTO = new FakeGetEntityByIdQuery()
            {
                Id = _fixture.AddedFakeEntity.Id
            };

            //act
            var commandResult = await _bus.SendMessage<FakeGetEntityByIdQuery, FakeGetEntityByIdViewModel>(fakeEntityDTO);

            // assert
            Assert.True(commandResult.ProccessCompleted);
            Assert.Equal(_fixture.AddedFakeEntity.Name.Value, commandResult.Result!.Name);
            Assert.Equal(_fixture.AddedFakeEntity.Description, commandResult.Result!.Description);
        }
        [Trait("Category", "1 - BaseCommandHandler")]
        [Fact(DisplayName = "4 - Update entity"), TestPriority(1.4)]
        public async Task UpdateEntityComandHandler_Success()
        {
            // arange
            var fakeEntityDTO = new FakeUpdateEntityCommand()
            {
                Id = _fixture.AddedFakeEntity.Id,
                Name = "cassiano editado",
                Description = "cassiano editado"
            };
            //act
            var commandResult = await _bus.SendMessage(fakeEntityDTO);

            // assert
            Assert.True(commandResult.ProccessCompleted); 
            var updatedEntity = await _repository.GetByIdAsync(_fixture.AddedFakeEntity.Id);
            Assert.Equal(fakeEntityDTO.Name, updatedEntity!.Name.Value);
            Assert.Equal(fakeEntityDTO.Description, updatedEntity!.Description);
            Assert.False(HasNotifications());
        }

        [Trait("Category", "1 - BaseCommandHandler")]
        [Fact(DisplayName = "5 - Update entity with domain error"), TestPriority(1.5)]
        public async Task UpdateEntityComandHandler_DomainError()
        {
            // arange
            var fakeEntityDTO = new FakeUpdateEntityCommand()
            {
                Id = _fixture.AddedFakeEntity.Id,
                Name = "cassiano editado",
            };
            //act
            var commandResult = await _bus.SendMessage(fakeEntityDTO);

            // assert
            Assert.True(commandResult.ProccessCompleted);
            Assert.True(HasNotifications());
        }

        [Trait("Category", "1 - BaseCommandHandler")]
        [Fact(DisplayName = "6 - Update entity with not found entity error"), TestPriority(1.6)]
        public async Task UpdateEntityComandHandler_NotFoundEntityError()
        {
            // arange
            var fakeEntityDTO = new FakeUpdateEntityCommand()
            {
                Id = Guid.NewGuid(),
                Name = "cassiano editado",
                Description = "cassiano editado"
            };

            //act
            var exception = await Assert.ThrowsAsync<ApplicationCoreException>(async () => await _bus.SendMessage(fakeEntityDTO));

            // assert
            Assert.Contains("not found to update", exception.InnerException!.Message);
        }


        //unit test to class FakeEntity
        [Trait("Category", "1 - BaseCommandHandler")]
        [Fact(DisplayName = "7 - Delete entity"), TestPriority(1.9)]
        public async Task DeleteEntityComandHandler_SuccessAsync()
        {
            // arange
            var fakeEntityDTO = new FakeDeleteEntityCommand()
            {
                Id = _fixture.AddedFakeEntity.Id
            };

            //act
            var commandResult = await _bus.SendMessage(fakeEntityDTO);
            var deletedEntity = await _repository.GetByIdAsync(_fixture.AddedFakeEntity.Id);

            // assert
            Assert.True(commandResult.ProccessCompleted);
            Assert.False(HasNotifications());
            Assert.Null(deletedEntity);
        }



        private IEnumerable<Notification> GetNotifications()
        {
            return _domainNotificationService.GetAll().Where(notification => notification.Code != "testinfra");
        }
        private bool HasNotifications()
        {
            return GetNotifications().Any();
        }

    }
}
