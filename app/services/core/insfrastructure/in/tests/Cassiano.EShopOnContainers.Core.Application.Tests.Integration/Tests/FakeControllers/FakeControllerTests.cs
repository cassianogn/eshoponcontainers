using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.FakesInfra;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.IoC;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeGetEntityById;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeControllers
{

    [TestCaseOrderer("Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders.PriorityOrderer", "Cassiano.EShopOnContainers.Core.Application.Tests.Integration")]
    [Collection(nameof(FakeControllerCollection))]
    public class FakeControllerTests
    {

        private readonly BusService _bus;
        private readonly DomainNotificationService _domainNotificationService;
        private readonly FakeControllerFixture _fixture;
        private readonly IFakeEntityRepository _repository;
        private readonly FakeController _controller;


        public FakeControllerTests(FakeControllerFixture fixture)
        {

            var providers = TestsServiceProvider.GetServiceProvider(service => new FakeCleanInfrastructureBus());
            _bus = providers.GetRequiredService<BusService>();
            _domainNotificationService = providers.GetRequiredService<DomainNotificationService>();
            _repository = providers.GetRequiredService<IFakeEntityRepository>();
            _fixture = fixture;
            _controller = new FakeController(_domainNotificationService, TestsServiceProvider.HttpRequest(), _bus);
        }

        [Trait("Category", "2 - BaseController"), TestPriority(2.1)]
        [Fact(DisplayName = "1 - AddEntity Success")]
        public async Task BaseController_Create_Success()
        {
            var command = new FakeCreateEntityCommand()
            {
                Name = "test",
                Description = "test"
            };
            var result = await _controller.AddAsync(command) as CreatedResult;

            Assert.Equal(201, result!.StatusCode);
            var addedEntityId = (Guid)result.Value!.GetType().GetProperty("Id")!.GetValue(result.Value)!;
            var addedEntity = await _repository.GetByIdAsync(addedEntityId);
            _fixture.AddFakeEntity(addedEntity!);
        }

        [Trait("Category", "2 - BaseController"), TestPriority(2.2)]
        [Fact(DisplayName = "2 - AddEntity Error")]
        public async Task BaseController_Create_Error()
        {
            var command = new FakeCreateEntityCommand()
            {
            };
            var result = await _controller.AddAsync(command) as BadRequestObjectResult;

            Assert.Equal(400, result!.StatusCode);
            var resultValue = result.Value as List<Notification>;
            Assert.Contains(resultValue, resultValueItem => resultValueItem.Code == "The basic validation rule failed" && resultValueItem.Message == "Description is required");
        }

        [Trait("Category", "2 - BaseController"), TestPriority(2.3)]
        [Fact(DisplayName = "3 - GetEntityById Success")]
        public async Task BaseController_GetById_Success()
        {

            var result = await _controller.GetById(_fixture.AddedFakeEntity.Id) as OkObjectResult;
            var viewModel = (result!.Value as FakeGetEntityByIdViewModel)!;

            Assert.Equal(200, result!.StatusCode);
            Assert.Equal(_fixture.AddedFakeEntity.Id, viewModel.Id);
            Assert.Equal(_fixture.AddedFakeEntity.Name.Value, viewModel.Name);
            Assert.Equal(_fixture.AddedFakeEntity.Description, viewModel.Description);
        }

        [Trait("Category", "2 - BaseController"), TestPriority(2.4)]
        [Fact(DisplayName = "4 - Update entity Success")]
        public async Task BaseController_Update_Success()
        {
            var command = new FakeUpdateEntityCommand()
            {
                Id = _fixture.AddedFakeEntity.Id,
                Name = "test updated",
                Description = "test updated"
            };

            var result = await _controller.UpdateAsync(_fixture.AddedFakeEntity.Id, command) as NoContentResult;

            Assert.Equal(204, result!.StatusCode);
            var updatedEntity = await _repository.GetByIdAsync(command.Id);
            Assert.Equal(command.Name, updatedEntity!.Name.Value);
            Assert.Equal(command.Description, updatedEntity!.Description);
            _fixture.AddFakeEntity(updatedEntity!);
        }
        
        [Trait("Category", "2 - BaseController"), TestPriority(2.5)]
        [Fact(DisplayName = "5 - Update entity with bad request")]
        public async Task BaseController_Update_WithError()
        {
            var command = new FakeUpdateEntityCommand()
            {
                Id = _fixture.AddedFakeEntity.Id,
                Name = "test updated",
                Description = "test updated"
            };
            var invalidId = Guid.NewGuid();
            var result = await _controller.UpdateAsync(invalidId, command) as BadRequestObjectResult;

            Assert.Equal(400, result!.StatusCode);
            Assert.Equal($"The provided id by URL don't is equal as DTO. the url: {invalidId}, DTO: {command.Id}", result.Value);
        }

        [Trait("Category", "2 - BaseController"), TestPriority(2.6)]
        [Fact(DisplayName = "6 - Delete entity Success")]
        public async Task BaseController_Delete_Success()
        {
            var result = await _controller.DeleteAsync(_fixture.AddedFakeEntity.Id) as NoContentResult;

            Assert.Equal(204, result!.StatusCode);
            var deletedEntity = await _repository.GetByIdAsync(_fixture.AddedFakeEntity.Id);
            Assert.Null(deletedEntity);
        }
    }
}
