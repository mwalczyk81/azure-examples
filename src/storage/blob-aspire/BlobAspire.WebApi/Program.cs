using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
{
    var conn = builder.Configuration.GetConnectionString("BlobStorage")!;
    return new BlobServiceClient(conn);
});

var app = builder.Build();

app.MapPost("/upload", async (IFormFile file, BlobServiceClient client) =>
{
    var container = client.GetBlobContainerClient("samples");
    await container.CreateIfNotExistsAsync();
    using var stream = file.OpenReadStream();
    await container.UploadBlobAsync(file.FileName, stream);
    return Results.Ok();
});

app.MapGet("/download/{name}", async (string name, BlobServiceClient client) =>
{
    var container = client.GetBlobContainerClient("samples");
    var blob = container.GetBlobClient(name);
    if (!await blob.ExistsAsync())
    {
        return Results.NotFound();
    }

    var download = await blob.DownloadContentAsync();
    return Results.File(download.Value.Content.ToStream(), "application/octet-stream", name);
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public partial class Program { }
