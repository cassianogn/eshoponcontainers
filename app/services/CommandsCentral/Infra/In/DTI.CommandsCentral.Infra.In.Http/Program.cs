using DTI.CommandsCentral.Infra.CrossCutting;
using DTI.CommandsCentral.Infra.In.Http;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;
using Prometheus.DotNetRuntime;

var builder = WebApplication.CreateBuilder(args);
//using IDisposable Collector = CreateCollector();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationWithDependencies(builder.Configuration);
builder.Services.AddHostedService<AppBackgroundServices>();
//builder.Services.AddHealthChecks()
builder.Services.AddControllers();

var app = builder.Build();
var counter = Metrics.CreateCounter("CommandsCentralMetricsCounter", "Conta os requests para os endpoints",
    new CounterConfiguration()
    {
        LabelNames = new[] { "method", "endpoint" }
    });
app.Use((context, next) =>
{
    counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
    return next();
});
app.UseHttpMetrics();
app.UseMetricServer();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

//static IDisposable CreateCollector()
//{
//    var builder = DotNetRuntimeStatsBuilder.Customize()
//        .WithContentionStats(CaptureLevel.Informational)
//        .WithGcStats(CaptureLevel.Verbose)
//        .WithThreadPoolStats(CaptureLevel.Informational)
//        .WithExceptionStats(CaptureLevel.Errors)
//        .WithJitStats();

//    builder.RecycleCollectorsEvery(new TimeSpan(0, 20, 0));

//    return builder.StartCollecting();
//}