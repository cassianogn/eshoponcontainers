using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EShopOnContainer.Catalog.Infra.CrossCutting;

namespace EShopOnContainer.Catalog.Infra.In.Tests
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
