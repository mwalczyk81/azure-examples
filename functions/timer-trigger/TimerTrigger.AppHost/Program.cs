using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("functionapp", "../TimerTrigger.FunctionApp/TimerTrigger.FunctionApp.csproj");

builder.Build().Run();
