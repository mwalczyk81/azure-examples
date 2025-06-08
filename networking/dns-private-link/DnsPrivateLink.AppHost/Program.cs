using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var dns = builder.AddProject("dnsservice", "../FakeDnsApi/FakeDnsApi.csproj");

builder.AddProject("webapi", "../DnsPrivateLink.WebApi/DnsPrivateLink.WebApi.csproj")
    .WithReference(dns);

builder.Build().Run();
