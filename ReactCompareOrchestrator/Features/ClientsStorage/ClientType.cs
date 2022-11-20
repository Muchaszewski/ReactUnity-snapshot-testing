namespace ReactCompareOrchestrator.Features.ClientsStorage;

/// <summary>
///     Represents a client storage.
/// </summary>
public class ClientType : IClientType
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientType"/> class.
    /// </summary>
    /// <param name="connectionId"></param>
    /// <param name="appType"></param>
    /// <param name="appVersion"></param>
    public ClientType(string connectionId, string appType, string appVersion)
    {
        ConnectionId = connectionId;
        AppType = appType;
        AppVersion = appVersion;
    }

    /// <summary>
    ///     Id of the client. It's the same as the ConnectionId.
    /// </summary>
    public string Id => ConnectionId;

    /// <inheritdoc />
    public string ConnectionId { get; init; }

    /// <inheritdoc />
    public string AppType { get; init; }

    /// <inheritdoc />
    public string AppVersion { get; init; }
}