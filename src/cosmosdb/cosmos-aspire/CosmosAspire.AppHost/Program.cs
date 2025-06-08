using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CosmosAspire_WebApi>("webapi");

builder.Build().Run();
