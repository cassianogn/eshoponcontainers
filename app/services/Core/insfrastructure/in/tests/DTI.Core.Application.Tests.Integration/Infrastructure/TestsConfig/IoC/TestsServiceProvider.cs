using DTI.Core.Application.Tests.Integration.Domain.FakieEntities;
using DTI.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using DTI.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities;
using DTI.Core.Application.Tests.Integration.Infrastructure.FakesInfra;
using DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers;
using DTI.Core.Domain.Auth;
using DTI.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DTI.Core.Application.Tests.Integration.Infrastructure.TestsConfig.IoC
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
