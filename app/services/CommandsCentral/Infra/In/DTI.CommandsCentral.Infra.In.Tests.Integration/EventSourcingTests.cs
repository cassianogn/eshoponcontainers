using DTI.CommandsCentral.Application.In.SaveEventStored;
using DTI.CommandsCentral.Infra.In.Tests.Integration.Infrastructure;
using DTI.Core.Domain.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DTI.CommandsCentral.Infra.In.Tests.Integration
{
    public class EventSourcingTests
    {
       
        public EventSourcingTests()
        {
            //_serviceProvider = new TestServiceProvider().ServiceProvider;
            //_mediator = _serviceProvider.GetService<IMediator>()!;
        }

        
        public void EventStoredSuccess()
        {
           

            Assert.True(true);

        }
    }
}