using DTI.CommandsCentral.Infra.CrossCutting;
using DTI.CommandsCentral.Infra.In.Http;
using DTI.CommandsCentral.Infra.In.Http.Elk;
using Elastic.Apm.NetCoreAll;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Host.UseSerilog();

builder.Services.AddObservabilityModule(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationWithDependencies(builder.Configuration);
builder.Services.AddHostedService<AppBackgroundServices>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAllElasticApm(builder.Configuration);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();