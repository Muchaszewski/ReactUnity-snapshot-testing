namespace ReactCompareOrchestrator.Features.ClientsStorage;

/// <summary>
///     Represents a client storage.
/// </summary>
public interface IClientType
{
    /// <summary>
    ///     Gets the client Id.
    /// </summary>
    public string Id { get; }

    /// <summary>
    ///     Connection Id of the signalR client.
    /// </summary>
    public string ConnectionId { get; }

    /// <summary>
    ///     Type of the application that is hosting testing runners.
    /// </summary>
    public string AppType { get; init; }

    /// <summary>
    ///     Version of the application for version control
    /// </summary>
    public string AppVersion { get; init; }
}