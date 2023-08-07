using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.FakesInfra;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.IoC
{
    public static class TestsServiceProvider
    {
        public static IServiceProvider GetServiceProvider<TInfrastructureBusService>(Func<IServiceProvider, TInfrastructureBusService> instanceOfInfrastructureBusDelegate) where TInfrastructureBusService : class, IInfrastructureBusService
        {
            var services = new ServiceCollection();
            services.AddCoreApplication(new List<Assembly>() { typeof(EntityCrudCommandHandlerTest).Assembly }, instanceOfInfrastructureBusDelegate);
            services.AddDbContext<TestDb>();
            services.AddScoped<IFakeEntityRepository, FakeEntityRepository>();
            return services.BuildServiceProvider();
        }

        public static UserHttpRequest HttpRequest() => new TestUserHttpRequest();

    }
}
