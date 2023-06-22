using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Events.TestBusMemoryWithReturn
{
    public class TestBusMemoryWithReturnEventHandler : INotificationHandler<TestBusMemoryWithReturnEvent>
    {
        private readonly DomainNotificationService _domainNotificationService;
        public TestBusMemoryWithReturnEventHandler(DomainNotificationService domainNotificationService)
        {
            _domainNotificationService = domainNotificationService;
        }
        public Task Handle(TestBusMemoryWithReturnEvent notification, CancellationToken cancellationToken)
        {
            _domainNotificationService.Add("test1", "the first message has proccess");
            return Task.CompletedTask;
        }
    }
}
