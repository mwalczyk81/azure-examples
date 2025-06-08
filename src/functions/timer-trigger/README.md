# Aspire Timer Trigger Function

This sample shows how to run an Azure Function on .NET 8 using the Aspire AppHost.
The function logs a heartbeat message every five minutes.

## Running with Aspire

From this folder run:

```bash
 dotnet run --project TimerTrigger.AppHost
```

The AppHost starts the function application with logging and configuration wired
through Aspire. Logs appear in the console.

## Running with Azure Functions Core Tools

Alternatively run the function directly using [Azure Functions Core Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-local):

```bash
 func start --csharp
```

Ensure `AzureWebJobsStorage` is configured in `TimerTrigger.FunctionApp/local.settings.json`.

The timer will fire immediately and then every five minutes.
