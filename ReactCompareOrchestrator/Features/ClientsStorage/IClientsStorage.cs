namespace ReactCompareOrchestrator.Features.ClientsStorage;

public interface IClientsStorage
{
    /// <summary>
    ///     Adds a new client to the storage.
    /// </summary>
    /// <param name="client"></param>
    public void AddClient(IClientType client);
    
    /// <summary>
    ///     Removes a client from the storage.
    /// </summary>
    /// <param name="client"></param>
    public void RemoveClient(IClientType client);
    
    /// <summary>
    ///     Returns a list of all clients in the storage.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IClientType> GetClients(int page, int pageSize);
    
    /// <summary>
    ///     Gets client by id.
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    public IClientType? GetClient(string clientId);
}