using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzureExamples;

public interface IServiceBus
{
    Task<IEnumerable<string>> ReceiveMessagesAsync(string connectionString, CancellationToken cancellationToken = default);
}

public interface IKeyVault
{
    Task<string> GetSecretAsync(string secretName, CancellationToken cancellationToken = default);
}

public class EventReader
{
    private readonly IServiceBus _serviceBus;
    private readonly IKeyVault _keyVault;
    private readonly string _connectionStringSecretName;

    public EventReader(IServiceBus serviceBus, IKeyVault keyVault, string connectionStringSecretName)
    {
        _serviceBus = serviceBus;
        _keyVault = keyVault;
        _connectionStringSecretName = connectionStringSecretName;
    }

    public async Task<IList<string>> ReadEventsAsync(CancellationToken cancellationToken = default)
    {
        var connectionString = await _keyVault.GetSecretAsync(_connectionStringSecretName, cancellationToken);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string missing.");
        }

        var events = await _serviceBus.ReceiveMessagesAsync(connectionString, cancellationToken);
        return events.ToList();
    }
}
