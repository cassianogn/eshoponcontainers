using DTI.Core.Domain.Services.DomainNotifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DTI.Core.Domain.Tests.Unit.Bus.TestBusMemory.Events.TestBusMemoryWithReturn
{
    internal class TestNotRunEventHandler : INotificationHandler<TestNotRunEvent>
    {
        private readonly DomainNotificationService _domainNotificationService;

        public Task Handle(TestNotRunEvent notification, CancellationToken cancellationToken)
        {
            _domainNotificationService.Add("error", "the handler shouldn't run");
            return Task.CompletedTask;
        }
    }
}
