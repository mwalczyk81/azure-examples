using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var dns = builder.AddProject<Projects.FakeDnsApi>("dnsservice");

builder.AddProject<Projects.DnsPrivateLink_WebApi>("webapi")
    .WithReference(dns);

builder.Build().Run();
