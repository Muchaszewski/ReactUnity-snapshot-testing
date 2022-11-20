using System.Collections.Concurrent;

namespace ReactCompareOrchestrator.Features.ClientsStorage;

/// <summary>
///     A storage for clients using ConcurrentDictionary.
/// </summary>
public class InMemoryClientStorage : IClientsStorage
{
    private readonly ConcurrentDictionary<string, IClientType> _clients = new ();

    /// <inheritdoc />
    public void AddClient(IClientType client)
    {
        _clients.TryAdd(client.Id, client);
    }

    /// <inheritdoc />
    public void RemoveClient(IClientType client)
    {
        _clients.TryRemove(client.Id, out _);
    }

    /// <inheritdoc />
    public IEnumerable<IClientType> GetClients(int page, int pageSize)
    {
        return _clients.Values.Skip(page * pageSize).Take(pageSize);
    }

    /// <inheritdoc />
    public IClientType? GetClient(string clientId)
    {
        return _clients.TryGetValue(clientId, out var client) ? client : null;
    }
}