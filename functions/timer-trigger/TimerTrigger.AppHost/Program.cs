using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var function = builder.AddProject<Projects.TimerTrigger_FunctionApp>("functionapp");

builder.Build().Run();
