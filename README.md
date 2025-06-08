# Azure Examples

This repository shows a minimal .NET solution structured with `src` and `tests` folders. The sample `EventReader` class reads events from a service bus using a connection string from Key Vault.

## Running tests

Execute the tests with the .NET SDK:

```bash
dotnet test AzureExamples.sln
```

The `tests` project includes examples of using mocks and fakes to keep the microservice isolated from Azure during testing.
These tests demonstrate how to:

- pass `CancellationToken` values through to dependencies
- propagate exceptions thrown by mocked services
- run integration-style tests with in-memory fakes instead of Azure resources
