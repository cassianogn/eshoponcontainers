using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithoutReturn
{
    internal class TestBusMemoryWithoutReturnCommandHandler : BaseRequestHandler<TestBusMemoryWithoutReturnCommand>
    {
        private readonly DomainNotificationService _domainNotificationService;

        public TestBusMemoryWithoutReturnCommandHandler(IMediator mediator, DomainNotificationService domainNotificationService) : base(mediator)
        {
            _domainNotificationService = domainNotificationService;
        }

        public override Task<CommandResult> ExecuteAsync(TestBusMemoryWithoutReturnCommand request, CancellationToken cancellationToken)
        {
            _domainNotificationService.Add("test", "the first message has proccess");
            return Task.FromResult(CommandResult.GetSuccess());
        }

        protected override EventType GetEventType()
        {
            return EventType.Create;
        }

    }
}
