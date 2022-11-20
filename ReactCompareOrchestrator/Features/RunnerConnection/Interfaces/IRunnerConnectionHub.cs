namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

public interface IRunnerConnectionHub
{
    /// <summary>
    ///     Occurs when a new connection is established.
    /// </summary>
    /// <returns></returns>
    public Task OnConnectedAsync();

    /// <summary>
    ///     Occurs when a connection is closed.
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public Task OnDisconnectedAsync(Exception? exception);

    /// <summary>
    ///     Called after the connection has been established and the client has been authenticated.
    /// </summary>
    /// <returns></returns>
    public Task<IRegisterClientResponse> RegisterClientAsync(IRegisterClientRequest request);

    /// <summary>
    ///     Called when the client is ready to receive tests to run.
    /// </summary>
    /// <returns></returns>
    public Task<IRegisterTestRunnerResponse> RegisterTestRunnerAsync(IRegisterTestRunnerRequest request);

    /// <summary>
    ///     Called when there is a progress update for a test.
    /// </summary>
    /// <param name="progress"></param>
    /// <returns></returns>
    public Task TestRunnerProgress(ITestRunnerProgress progress);
}