using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BlobAspire_WebApi>("webapi");

builder.Build().Run();
