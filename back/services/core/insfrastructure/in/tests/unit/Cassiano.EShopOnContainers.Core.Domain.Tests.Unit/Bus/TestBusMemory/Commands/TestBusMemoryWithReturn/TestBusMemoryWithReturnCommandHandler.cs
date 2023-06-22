using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithReturn
{
    internal class TestBusMemoryWithReturnCommandHandler : BaseRequestResponseHandler<TestBusMemoryWithReturnCommand, Guid>
    {
        private readonly DomainNotificationService _domainNotificationService;

        public TestBusMemoryWithReturnCommandHandler(IMediator mediator, DomainNotificationService domainNotificationService) : base(mediator)
        {
            _domainNotificationService = domainNotificationService;
        }


        public override Task<CommandResult<Guid>> ExecuteAsync(TestBusMemoryWithReturnCommand request, CancellationToken cancellationToken)
        {
            _domainNotificationService.Add("test", "the first message has proccess");
            return Task.FromResult(CommandResult<Guid>.GetSuccess(Guid.NewGuid()));
        }

        protected override EventType GetEventType()
        {
            return EventType.Create;
        }
    }
}
