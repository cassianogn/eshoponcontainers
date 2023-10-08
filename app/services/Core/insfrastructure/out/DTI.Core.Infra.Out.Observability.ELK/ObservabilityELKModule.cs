using Elastic.Apm.NetCoreAll;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace DTI.Core.Infra.Out.Observability.ELK
{
    public static class ObservabilityELKModule
    {
        public static Action<WebApplication> AddObservabilityELK(this WebApplicationBuilder builder, string @namespace)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseSerilog();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

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
                   config.DataStream = new DataStreamName("logs", "eshop-on-container", @namespace);
                   config.BootstrapMethod = BootstrapMethod.Failure;
               });
           })
           .Enrich.WithProperty("Environment", environment)
           .ReadFrom.Configuration(builder.Configuration)
           .CreateLogger();

            return app =>
            {
                app.UseSerilogRequestLogging();
                app.UseAllElasticApm(builder.Configuration);
            };

        }
    }
}
