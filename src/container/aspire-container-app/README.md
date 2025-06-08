# Aspire Container App

This sample demonstrates running a minimal API with [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) in Azure Container Apps. The `/info` endpoint returns basic environment information.

## Prerequisites
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- Docker

## Running locally

```bash
cd container/aspire-container-app
dotnet run --project AspireContainerApp.AppHost
```

Open `http://localhost:5000/swagger` to test the API.

## Build the container image

```bash
docker build -t <acr-name>.azurecr.io/aspire-container-app:latest .
```

Push the image to your Azure Container Registry:

```bash
az acr login --name <acr-name>
docker push <acr-name>.azurecr.io/aspire-container-app:latest
```

## Deploy to Azure Container Apps

```bash
az containerapp create \
  --name aspire-container-app \
  --resource-group <resource-group> \
  --environment <containerapps-env> \
  --image <acr-name>.azurecr.io/aspire-container-app:latest \
  --ingress external \
  --target-port 8080
```

Replace the placeholders with your ACR name, resource group and Container Apps environment.
