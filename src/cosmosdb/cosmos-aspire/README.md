# Aspire Cosmos DB Example

This sample demonstrates how to use [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) with the Azure Cosmos DB SDK.
It exposes minimal API endpoints for managing **Product** items stored in a Cosmos DB container.

## Configuration

Create `CosmosAspire.WebApi/appsettings.Development.json` and supply your Cosmos DB connection string:

```json
{
  "ConnectionStrings": {
    "CosmosDb": "<your-cosmos-connection-string>"
  }
}
```

## Running the sample

From this directory run:

```bash
 dotnet run --project CosmosAspire.AppHost
```

The API will be available at `http://localhost:5000/swagger` for testing the CRUD endpoints.
