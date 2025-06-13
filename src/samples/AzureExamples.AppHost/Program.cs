using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BlobAspire_WebApi>("blobapi");
builder.AddProject<Projects.CosmosAspire_WebApi>("cosmosapi");
builder.AddProject<Projects.AspireWeb_WebApi>("webfrontend");

builder.Build().Run();
