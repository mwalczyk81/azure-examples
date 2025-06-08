using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TimerTrigger_FunctionApp>("functionapp");

builder.Build().Run();
