using Azure.Cosmos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
{
    var conn = builder.Configuration.GetConnectionString("CosmosDb")!;
    return new CosmosClient(conn);
});

var app = builder.Build();

app.MapPost("/products", async ([FromBody] Product product, CosmosClient client) =>
{
    var container = await GetContainerAsync(client);
    var response = await container.CreateItemAsync(product, new PartitionKey(product.Id));
    return Results.Created($"/products/{response.Resource.Id}", response.Resource);
});

app.MapGet("/products/{id}", async (string id, CosmosClient client) =>
{
    var container = await GetContainerAsync(client);
    try
    {
        var response = await container.ReadItemAsync<Product>(id, new PartitionKey(id));
        return Results.Ok(response.Resource);
    }
    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
    {
        return Results.NotFound();
    }
});

app.MapGet("/products", async (CosmosClient client) =>
{
    var container = await GetContainerAsync(client);
    var query = container.GetItemQueryIterator<Product>("SELECT * FROM c");
    var results = new List<Product>();
    while (query.HasMoreResults)
    {
        var resp = await query.ReadNextAsync();
        results.AddRange(resp);
    }
    return Results.Ok(results);
});

app.MapPut("/products/{id}", async (string id, [FromBody] Product product, CosmosClient client) =>
{
    var container = await GetContainerAsync(client);
    product.Id = id;
    var response = await container.UpsertItemAsync(product, new PartitionKey(id));
    return Results.Ok(response.Resource);
});

app.MapDelete("/products/{id}", async (string id, CosmosClient client) =>
{
    var container = await GetContainerAsync(client);
    try
    {
        await container.DeleteItemAsync<Product>(id, new PartitionKey(id));
        return Results.NoContent();
    }
    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
    {
        return Results.NotFound();
    }
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

static async Task<Container> GetContainerAsync(CosmosClient client)
{
    var dbResponse = await client.CreateDatabaseIfNotExistsAsync("samples");
    var db = dbResponse.Database;
    var containerResponse = await db.CreateContainerIfNotExistsAsync("products", "/id");
    return containerResponse.Container;
}

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public partial class Program { }
