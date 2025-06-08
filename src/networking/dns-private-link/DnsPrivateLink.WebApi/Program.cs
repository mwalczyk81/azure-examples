using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dnsUrl = builder.Configuration["DnsService:BaseUrl"] ?? "http://localhost:5050";
builder.Services.AddHttpClient("dns", client => client.BaseAddress = new Uri(dnsUrl));

var app = builder.Build();

app.MapGet("/lookup/{name}", async (string name, IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("dns");
    var response = await client.GetFromJsonAsync<DnsResponse>($"/resolve?name={name}");
    return response is null ? Results.NotFound() : Results.Ok(response);
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public record DnsResponse(string Name, string Address);

public partial class Program { }
