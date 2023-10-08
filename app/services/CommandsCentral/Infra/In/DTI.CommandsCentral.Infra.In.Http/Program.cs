using DTI.CommandsCentral.Infra.CrossCutting;
using DTI.CommandsCentral.Infra.In.Http;

var builder = WebApplication.CreateBuilder(args);
var webApplicationObservabilityConfiguration = builder.AddObservability();

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

webApplicationObservabilityConfiguration.Invoke(app);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();