using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireWeb_WebApi>("webapi");

builder.Build().Run();
