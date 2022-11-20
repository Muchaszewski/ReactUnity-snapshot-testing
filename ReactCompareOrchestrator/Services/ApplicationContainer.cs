using ReactCompareOrchestrator.Interfaces;

namespace ReactCompareOrchestrator.Services;

/// <summary>
///     An container that can manage multiple test runners clients
/// </summary>
public class ApplicationContainer : IApplicationContainer
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    public ApplicationContainer(string connectionId)
    {
        TestRunners = new List<ITestRunnerClient>();
        ConnectionId = connectionId;
    }

    /// <summary>
    ///     List of all test runners that are currently registered with the orchestrator
    /// </summary>
    private List<ITestRunnerClient> TestRunners { get; set; }

    /// <summary>
    ///     Connection ID that is used to connect to this application container
    /// </summary>
    public string ConnectionId { get; }

    /// <summary>
    ///     List of all the test runners
    /// </summary>
    public IReadOnlyList<ITestRunnerClient> Clients => TestRunners;

    /// <summary>
    ///     Gets the test runner that is currency idle for given app type
    ///     If no test runner is available, returns null
    /// </summary>
    /// <param name="appType"></param>
    /// <returns></returns>
    public ITestRunnerClient? GetFreeTestRunner(AppTypeEnum appType)
    {
        return TestRunners.FirstOrDefault(x => x.AppType == appType && !x.IsRunning);
    }

    /// <summary>
    ///     Register a new test runner client
    /// </summary>
    /// <param name="typeEnum">Type of the client</param>
    /// <returns></returns>
    public ITestRunnerClient RegisterClient(AppTypeEnum typeEnum)
    {
        var client = new TestRunnerClient(this, typeEnum);
        TestRunners.Add(client);
        return client;
    }

    /// <summary>
    ///     Unregister a test runner client
    /// </summary>
    /// <param name="client"></param>
    public void UnregisterClient(ITestRunnerClient client)
    {
        TestRunners.Remove(client);
    }
}