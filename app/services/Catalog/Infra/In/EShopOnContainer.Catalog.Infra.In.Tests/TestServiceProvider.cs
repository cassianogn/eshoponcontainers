using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EShopOnContainer.Catalog.Infra.CrossCutting;
using Microsoft.AspNetCore.Builder;

namespace EShopOnContainer.Catalog.Infra.In.Tests
{
    internal class TestServiceProvider
    {
        public readonly ServiceProvider ServiceProvider;
        public TestServiceProvider()
        {
            var builder = WebApplication.CreateBuilder();

            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            var services = new ServiceCollection();

            var elasticCloudId = configuration.GetSection("Elasticsearch:CloudId").Value!;
            var elasticApiKey = configuration.GetSection("Elasticsearch:ApiKey").Value!;

            services.AddApplicationWithDependencies(configuration.GetSection("BusServiceConnection:Kafka").Value!, elasticCloudId, elasticApiKey);
            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
