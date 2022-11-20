namespace ReactCompareOrchestrator.Interfaces;

/// <summary>
///     An container that can manage multiple test runners clients
/// </summary>
public interface IApplicationContainer
{
    /// <summary>
    ///     Connection ID that is used to connect to this application container
    /// </summary>
    string ConnectionId { get; }
    
    /// <summary>
    ///     List of all the test runners
    /// </summary>
    IReadOnlyList<ITestRunnerClient> Clients { get; }
    
    /// <summary>
    ///     Gets the test runner that is currency idle for given app type
    /// </summary>
    /// <param name="appType"></param>
    /// <returns></returns>
    ITestRunnerClient? GetFreeTestRunner(AppTypeEnum appType);

    /// <summary>
    ///     Register a new test runner client
    /// </summary>
    /// <param name="typeEnum">Type of the client</param>
    /// <returns></returns>
    ITestRunnerClient RegisterClient(AppTypeEnum typeEnum);
    
    /// <summary>
    ///     Unregister a test runner client
    /// </summary>
    /// <param name="client"></param>
    void UnregisterClient(ITestRunnerClient client);
}