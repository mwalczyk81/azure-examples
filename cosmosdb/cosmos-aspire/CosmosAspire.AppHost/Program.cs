using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<Projects.CosmosAspire_WebApi>("webapi");

builder.Build().Run();
