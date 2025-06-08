using AzureExamples;
using NSubstitute;

namespace AzureExamples.Tests;

public class EventReaderTests
{
    [Fact]
    public async Task ReadEventsAsync_ReturnsEvents_WhenConnectionStringValid()
    {
        var serviceBus = Substitute.For<IServiceBus>();
        var keyVault = Substitute.For<IKeyVault>();
        keyVault.GetSecretAsync("conn", Arg.Any<CancellationToken>()).Returns(Task.FromResult("Endpoint=sb://test/"));
        serviceBus.ReceiveMessagesAsync("Endpoint=sb://test/", Arg.Any<CancellationToken>()).Returns(Task.FromResult<IEnumerable<string>>(new[] { "e1", "e2" }));

        var reader = new EventReader(serviceBus, keyVault, "conn");
        var result = await reader.ReadEventsAsync();

        Assert.Equal(new[] { "e1", "e2" }, result);
    }

    [Fact]
    public async Task ReadEventsAsync_Throws_WhenConnectionStringMissing()
    {
        var serviceBus = Substitute.For<IServiceBus>();
        var keyVault = Substitute.For<IKeyVault>();
        keyVault.GetSecretAsync("conn", Arg.Any<CancellationToken>()).Returns(Task.FromResult<string?>(null));

        var reader = new EventReader(serviceBus, keyVault, "conn");
        await Assert.ThrowsAsync<InvalidOperationException>(() => reader.ReadEventsAsync());
    }

    [Fact]
    public async Task Integration_ReadEventsAsync_UsesFakes()
    {
        var fakeServiceBus = new FakeServiceBus();
        var fakeKeyVault = new FakeKeyVault("Endpoint=sb://fake/");
        var reader = new EventReader(fakeServiceBus, fakeKeyVault, "conn");

        var events = await reader.ReadEventsAsync();

        Assert.Equal(new[] { "message1", "message2" }, events);
    }

    private class FakeServiceBus : IServiceBus
    {
        public Task<IEnumerable<string>> ReceiveMessagesAsync(string connectionString, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<string>>(new[] { "message1", "message2" });
        }
    }

    private class FakeKeyVault : IKeyVault
    {
        private readonly string _connectionString;
        public FakeKeyVault(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Task<string> GetSecretAsync(string secretName, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_connectionString);
        }
    }
}
