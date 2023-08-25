using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DTI.CommandsCentral.Infra.CrossCutting;

namespace DTI.CommandsCentral.Infra.In.Tests.Integration.Infrastructure
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
            services.AddApplicationWithDependencies(configuration);
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
