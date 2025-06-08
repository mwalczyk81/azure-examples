using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

builder .AddDashboard();

builder.AddProject<Projects.BlobAspire_WebApi>("blobapi");
builder.AddProject<Projects.CosmosAspire_WebApi>("cosmosapi");
builder.AddProject<Projects.AspireWeb_WebApi>("webfrontend");

builder.Build().Run();
