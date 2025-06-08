using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("webapi", "../AspireContainerApp.WebApi/AspireContainerApp.WebApi.csproj");

builder.Build().Run();
