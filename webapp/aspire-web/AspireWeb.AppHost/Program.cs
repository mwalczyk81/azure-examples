using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<Projects.AspireWeb_WebApi>("webapi");

builder.Build().Run();
