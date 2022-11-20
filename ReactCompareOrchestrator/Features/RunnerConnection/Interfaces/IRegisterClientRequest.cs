namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     Request to register a client that would host the runners
/// </summary>
public interface IRegisterClientRequest
{
    /// <summary>
    ///     Type of the application that is hosting testing runners.
    /// </summary>
    public string AppType { get; init; }

    /// <summary>
    ///     Version of the application for version control
    /// </summary>
    public string AppVersion { get; init; }
}