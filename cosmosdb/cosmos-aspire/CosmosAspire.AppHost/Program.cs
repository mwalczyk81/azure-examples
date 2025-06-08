using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("webapi", "../CosmosAspire.WebApi/CosmosAspire.WebApi.csproj");

builder.Build().Run();
