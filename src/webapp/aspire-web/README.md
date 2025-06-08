# Aspire Web API Example

This sample demonstrates how to use the [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) tooling to host a minimal Web API. It consists of two projects:

- **AspireWeb.AppHost** – the entry point that orchestrates the distributed application.
- **AspireWeb.WebApi** – the API service exposing endpoints with health checks, OpenTelemetry tracing and Swagger UI.

## Prerequisites
- [\.NET 8 SDK](https://dotnet.microsoft.com/download)

## Running the sample

From the repository root run:

```bash
cd webapp/aspire-web
dotnet run --project AspireWeb.AppHost
```

Once started, browse to `http://localhost:5000/swagger` to explore the API using Swagger UI. The health check endpoint is available at `http://localhost:5000/healthz`.
