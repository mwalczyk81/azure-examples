using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/info", () => new
{
    MachineName = Environment.MachineName,
    OS = RuntimeInformation.OSDescription,
    Environment = builder.Environment.EnvironmentName
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public partial class Program { }
