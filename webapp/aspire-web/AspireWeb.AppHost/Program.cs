using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("webapi", "../AspireWeb.WebApi/AspireWeb.WebApi.csproj");

builder.Build().Run();
