# Azure Examples

This repository contains small samples for common Azure workloads. The `src` folder hosts a minimal .NET example alongside additional folders for various services.
Each sample includes an **AppHost** project marked with `<IsAspireHost>true>`. The host references its API project using `builder.AddProject<Projects.MyApi>("myapi")` as described in the [Add Aspire to an existing app guide](https://learn.microsoft.com/dotnet/aspire/get-started/add-aspire-existing-app).

### Azure Examples Solution
A combined .NET Aspire solution is provided in `azure-examples.sln`. Run the AppHost locally with:

```bash
dotnet run --project samples/AzureExamples.AppHost
```
The Aspire dashboard requires environment variables specifying the port and OTLP endpoint:

```bash
ASPNETCORE_URLS=http://localhost:18888 \
ASPIRE_DASHBOARD_OTLP_HTTP_ENDPOINT_URL=http://localhost:4318 \
dotnet run --project samples/AzureExamples.AppHost
```

Run all tests with:

```bash
dotnet test azure-examples.sln
```

## Table of Contents
- [Functions](#functions)
- [Web App](#web-app)
- [Aspire Web](#aspire-web)
- [Storage](#storage)
- [Cosmos DB](#cosmos-db)
- [Container](#container)
- [Networking](#networking)
- [DevOps](#devops)
- [Running .NET Tests](#running-net-tests)

## Functions
Example Azure Functions project. To set up:
1. Navigate to `functions`.
2. Initialize a new Function App with the Azure Functions Core Tools.
3. Deploy using `func azure functionapp publish` or via GitHub Actions.
 - **Timer Trigger Aspire** – demonstrates a timer triggered function running under the Aspire AppHost. Run:

```bash
cd functions/timer-trigger
dotnet run --project TimerTrigger.AppHost
```

## Web App
Sample web application hosted on Azure App Service. To set up:
1. Navigate to `webapp`.
2. Create an App Service plan and web app with `az webapp up`.
3. Deploy your code using `git push` or CI/CD.

## Aspire Web
Minimal web API using .NET Aspire. To run locally:
1. Navigate to `webapp/aspire-web`.
2. Execute `dotnet run --project AspireWeb.AppHost`.
3. Open `http://localhost:5000/swagger` in your browser.

## Storage
Examples for Azure Storage accounts. To set up:
1. Navigate to `storage`.
2. Provision a storage account with `az storage account create`.
3. Explore blobs, queues, and tables using the Azure CLI or SDKs.

### Blob Aspire
A .NET Aspire sample that uploads and downloads blobs. Run:

```bash
cd storage/blob-aspire
dotnet run --project BlobAspire.AppHost
```

## Cosmos DB
Demonstrates connecting to Azure Cosmos DB. To set up:
1. Navigate to `cosmosdb`.
2. Create an account with `az cosmosdb create`.
3. Configure connection strings and run sample queries.

### Cosmos Aspire
A .NET Aspire sample using Azure Cosmos DB. Run:

```bash
cd cosmosdb/cosmos-aspire
dotnet run --project CosmosAspire.AppHost
```

## Container
Container-based workloads with Azure Container Instances or Azure Kubernetes Service. To set up:
1. Navigate to `container`.
2. Use `az acr build` to build images and `az container create` or `az aks` commands to run them.
3. Deploy using Bicep or ARM templates as needed.

### Aspire Container App
A minimal API hosted with .NET Aspire and deployable to Azure Container Apps. Run locally:

```bash
cd container/aspire-container-app
dotnet run --project AspireContainerApp.AppHost
```

## Networking
Examples of virtual networks and related resources. To set up:
1. Navigate to `networking`.
2. Create VNets, subnets, and gateways with the Azure CLI or Bicep.
3. Test connectivity between resources.

### DNS Private Link
A sample showing service discovery through a fake private DNS endpoint using .NET Aspire. Run:

```bash
cd networking/dns-private-link
dotnet run --project DnsPrivateLink.AppHost
```

## DevOps
CI/CD pipelines and infrastructure as code samples. To set up:
1. Navigate to `devops`.
2. Review pipeline YAML files or scripts.
3. Connect to Azure DevOps or GitHub Actions to automate deployments.
A workflow under `devops/gh-actions-aspire/azure-webapp.yml` builds, tests, and deploys the Aspire AppHost to Azure App Service.

## Running .NET Tests
The `src` folder contains the `EventReader` example with tests under `tests`.
Execute the tests with the .NET SDK:

```bash
dotnet test azure-examples.sln
```

The test project uses mocks and in-memory fakes to keep the sample independent from Azure services.
