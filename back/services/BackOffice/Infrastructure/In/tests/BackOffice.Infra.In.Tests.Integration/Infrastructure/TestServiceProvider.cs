using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EShopOnContainer.BackOffice.Infra.CrossCutting;

namespace BackOffice.Infra.In.Tests.Integration.Infrastructure
{
    internal class TestServiceProvider
    {
        public readonly ServiceProvider ServiceProvider;
        public TestServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            var services = new ServiceCollection();
            services.AddApplicationWithDependencies(configuration.GetConnectionString("DefaultConnection")!, configuration.GetSection("BusServiceConnection:Kafka").Value!);
            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
