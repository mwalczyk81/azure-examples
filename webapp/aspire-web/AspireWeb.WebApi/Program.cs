using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenTelemetry()
    .ConfigureResource(config => config.AddService("AspireWeb.WebApi"))
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter());

var app = builder.Build();

app.MapGet("/", () => "Hello from Aspire Web API!");
app.MapHealthChecks("/healthz", new HealthCheckOptions());

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public partial class Program { }
