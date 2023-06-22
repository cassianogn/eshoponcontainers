using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Events.TestBusMemoryWithReturn
{
    internal class TestBusMemoryWithReturnEventHandlerSecund : INotificationHandler<TestBusMemoryWithReturnEvent>
    {
        private readonly DomainNotificationService _domainNotificationService;

        public TestBusMemoryWithReturnEventHandlerSecund(DomainNotificationService domainNotificationService)
        {
            _domainNotificationService = domainNotificationService;
        }

        public Task Handle(TestBusMemoryWithReturnEvent notification, CancellationToken cancellationToken)
        {
            _domainNotificationService.Add("test2", "the secund message has proccess");
            return Task.CompletedTask;
        }
    }
}
