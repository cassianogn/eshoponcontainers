using Cassiano.EShopOnContainers.CommandsCentral.Application.In.SaveEventStored;
using Cassiano.EShopOnContainers.CommandsCentral.Domain.EventSourcing;
using Cassiano.EShopOnContainers.CommandsCentral.Infra.In.Tests.Integration.Infrastructure;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.In.Tests
{
    public class EventSourcingTests
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IEventStoredRepository _repository;

        public EventSourcingTests()
        {
            _serviceProvider = new TestServiceProvider().ServiceProvider;
            _mediator = _serviceProvider.GetService<IMediator>()!;
            _repository = _serviceProvider.GetService<IEventStoredRepository>()!;
        }

        [Trait("Category", "0 - CommandsCentral.EventStored")]
        [Fact(DisplayName = "1 - EventStored Success")]
        public async Task EventStoredSuccess()
        {
            var command = new SaveEventStoredCommand()
            {
                EventStored = new SaveEventStoredEvent()
                {
                    Id = Guid.NewGuid(),
                    EntityId = Guid.NewGuid(),
                    JsonCommand = "test",
                    CommandTypeOf = "test",
                    Date = DateTime.Now,
                    Type = EventType.Create,
                    Success = true,
                    FullException = "test",
                    MessageException = "test"
                }
            };

            _mediator.Send(command).Wait();


            var eventStored = (await _repository.GetByIdAsync(command.EventStored.Id))!;

            Assert.Equal(command.EventStored.EntityId, eventStored.EntityId!.Value);
            Assert.Equal(command.EventStored.JsonCommand, eventStored.JsonCommand);
            Assert.Equal(command.EventStored.CommandTypeOf, eventStored.CommandTypeOf);
            Assert.True((command.EventStored.Date.ToUniversalTime() - eventStored.Date.ToUniversalTime()).TotalMilliseconds < 2);
            Assert.Equal(command.EventStored.Type, eventStored.Type);
            Assert.Equal(command.EventStored.Success, eventStored.Success);
            Assert.Equal(command.EventStored.FullException, eventStored.FullException);
            Assert.Equal(command.EventStored.MessageException, eventStored.MessageException);
        }
    }
}