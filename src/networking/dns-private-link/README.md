# DNS Private Link Example

This sample demonstrates how [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) can handle service discovery when consuming a service through a private DNS endpoint. A fake DNS API simulates the private endpoint during local development.

## Running locally

```bash
cd networking/dns-private-link
dotnet run --project DnsPrivateLink.AppHost
```

The AppHost starts two services:

- **FakeDnsApi** – a mock DNS service listening on `http://localhost:5050`.
- **DnsPrivateLink.WebApi** – a Web API that resolves host names by calling the DNS service.

Browse to `http://localhost:5000/swagger` for the Web API and `http://localhost:5050/swagger` for the DNS service.

## Cloud-hosted setup

In a real environment the DNS API would be replaced by an endpoint accessible via [Azure Private Link](https://learn.microsoft.com/azure/private-link/). Aspire's `WithReference` passes the DNS service URL to the Web API. Configure the DNS base URL via the `DnsService__BaseUrl` environment variable or `appsettings.Development.json` when deploying.
