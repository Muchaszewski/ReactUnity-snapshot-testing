namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     Response from the server when registering a client
/// </summary>
public interface IRegisterClientResponse
{
    /// <summary>
    ///     The id of the client
    /// </summary>
    public string Id { get; set; }
}