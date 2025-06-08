using AzureExamples;
using NSubstitute;

namespace AzureExamples.Tests;

public class EventReaderIsolationTests
{
    [Fact]
    public async Task ReadEventsAsync_PassesCancellationTokenToDependencies()
    {
        var serviceBus = Substitute.For<IServiceBus>();
        var keyVault = Substitute.For<IKeyVault>();
        keyVault.GetSecretAsync("conn", Arg.Any<CancellationToken>())
                .Returns(Task.FromResult("Endpoint=sb://test/"));
        serviceBus.ReceiveMessagesAsync("Endpoint=sb://test/", Arg.Any<CancellationToken>())
                  .Returns(Task.FromResult<IEnumerable<string>>(Array.Empty<string>()));

        var reader = new EventReader(serviceBus, keyVault, "conn");
        using var cts = new CancellationTokenSource();

        await reader.ReadEventsAsync(cts.Token);

        await keyVault.Received(1).GetSecretAsync("conn", cts.Token);
        await serviceBus.Received(1).ReceiveMessagesAsync("Endpoint=sb://test/", cts.Token);
    }

    [Fact]
    public async Task ReadEventsAsync_ServiceBusThrows_PropagatesException()
    {
        var serviceBus = Substitute.For<IServiceBus>();
        var keyVault = Substitute.For<IKeyVault>();
        keyVault.GetSecretAsync("conn", Arg.Any<CancellationToken>())
                .Returns(Task.FromResult("Endpoint=sb://test/"));
        serviceBus.ReceiveMessagesAsync("Endpoint=sb://test/", Arg.Any<CancellationToken>())
                  .Returns(Task.FromException<IEnumerable<string>>(new InvalidOperationException("boom")));

        var reader = new EventReader(serviceBus, keyVault, "conn");

        await Assert.ThrowsAsync<InvalidOperationException>(() => reader.ReadEventsAsync());
    }

    [Fact]
    public async Task ReadEventsAsync_KeyVaultThrows_PropagatesException()
    {
        var serviceBus = Substitute.For<IServiceBus>();
        var keyVault = Substitute.For<IKeyVault>();
        keyVault.GetSecretAsync("conn", Arg.Any<CancellationToken>())
                .Returns(Task.FromException<string>(new InvalidOperationException("boom")));

        var reader = new EventReader(serviceBus, keyVault, "conn");

        await Assert.ThrowsAsync<InvalidOperationException>(() => reader.ReadEventsAsync());
    }
}
