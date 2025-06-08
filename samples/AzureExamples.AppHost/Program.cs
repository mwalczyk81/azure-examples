using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("blobapi", "../../storage/blob-aspire/BlobAspire.WebApi/BlobAspire.WebApi.csproj");
builder.AddProject("cosmosapi", "../../cosmosdb/cosmos-aspire/CosmosAspire.WebApi/CosmosAspire.WebApi.csproj");
builder.AddProject("webfrontend", "../../webapp/aspire-web/AspireWeb.WebApi/AspireWeb.WebApi.csproj");

builder.Build().Run();
