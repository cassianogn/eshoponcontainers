using DTI.Core.Domain.EventSourcing;
using DTI.Core.Domain.Services.Bus.Bases;
using DTI.Core.Domain.Services.Bus.Models;
using DTI.Core.Domain.Services.DomainNotifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DTI.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithoutReturn
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
            if (request.ThrowError)
                throw new Exception("Expected Error");

            return Task.FromResult(CommandResult.CommandFinished());
        }

        protected override EventType GetEventType()
        {
            return EventType.Create;
        }

    }
}
