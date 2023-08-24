using Cassiano.EShopOnContainers.CommandsCentral.Application.In.SaveEventStored;
using Cassiano.EShopOnContainers.CommandsCentral.Infra.In.Tests.Integration.Infrastructure;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.In.Tests.Integration
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