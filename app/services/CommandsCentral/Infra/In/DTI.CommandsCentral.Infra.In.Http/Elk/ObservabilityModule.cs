using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Microsoft.AspNetCore.Http.Features;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace DTI.CommandsCentral.Infra.In.Http.Elk
{
    public static class ObservabilityModule
    {
        public static IServiceCollection AddObservabilityModule(this IServiceCollection services, IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //var client = new ElasticsearchClient("0634905f87ce4532b028ef27f7812bb4:ZWFzdHVzMi5henVyZS5lbGFzdGljLWNsb3VkLmNvbTo0NDMkY2E3OTNmOGIxMWJhNDhhZjg0MWY5NGI3Mzg4MGU0NzYkNzNkYzhlOWQ1MGRmNGVhNWEzYWZiMzBiOGFkNTdmYTU=", new ApiKey("Mzc1QzdZb0JJN1VPZnl0Rk1WVTE6SXJucklyQTBTU0NWbzdKdFBzRm9JUQ=="));
            //services.AddSingleton(client);

            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information)
            .Enrich.WithExceptionDetails()
            .Enrich.WithCorrelationId()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.Async(writeTo =>
            {
                writeTo.ElasticCloud("0634905f87ce4532b028ef27f7812bb4:ZWFzdHVzMi5henVyZS5lbGFzdGljLWNsb3VkLmNvbTo0NDMkY2E3OTNmOGIxMWJhNDhhZjg0MWY5NGI3Mzg4MGU0NzYkNzNkYzhlOWQ1MGRmNGVhNWEzYWZiMzBiOGFkNTdmYTU=", "Mzc1QzdZb0JJN1VPZnl0Rk1WVTE6SXJucklyQTBTU0NWbzdKdFBzRm9JUQ==", config =>
                {
                    config.DataStream = new DataStreamName("logs", "dti-example", "demo");
                    config.BootstrapMethod = BootstrapMethod.Failure;
                });
            })
            .Enrich.WithProperty("Environment", environment)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

            

            return services;
        }
        //public static ElasticsearchSinkOptions ConfigureElasticSink( string environment)
        //{
        //    return new Elastic.Serilog.Sinks.ElasticsearchSinkOptions( HttpTransport.())
        //    //return new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
        //    {
        //        AutoRegisterTemplate = true,
        //        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
        //    };
        //}
       
    }
}
