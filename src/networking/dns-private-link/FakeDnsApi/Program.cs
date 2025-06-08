var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/resolve", (string name) => new DnsResponse(name, "10.0.0.1"));

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public record DnsResponse(string Name, string Address);

public partial class Program { }
