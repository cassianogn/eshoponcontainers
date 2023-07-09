using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.Fakes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Core
{
    public static  class TestsServiceProvider
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddCoreApplication<FakeInfrastructureBus>(new List<Assembly>() { typeof(EntityCrudCommandHandlerTest).Assembly });
            services.AddDbContext<TestDb>();
            services.AddScoped<IFakeEntityRepository, FakeEntityRepository>();
            return services.BuildServiceProvider();
        }
    }
}
