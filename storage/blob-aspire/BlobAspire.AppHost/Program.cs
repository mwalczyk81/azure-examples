using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("webapi", "../BlobAspire.WebApi/BlobAspire.WebApi.csproj");

builder.Build().Run();
