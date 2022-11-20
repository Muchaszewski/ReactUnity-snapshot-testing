namespace ReactCompareOrchestrator.Interfaces;

/// <summary>
///     A test runner client that can be used to run tests
/// </summary>
public interface ITestRunnerClient
{
    /// <summary>
    ///     Parent container
    /// </summary>
    IApplicationContainer Parent { get; }
    
    /// <summary>
    ///     Unique identifier of the test runner client
    /// </summary>
    Guid Id { get; }
    
    /// <summary>
    ///     Type of the test runner client
    /// </summary>
    AppTypeEnum AppType { get; }
    
    /// <summary>
    ///     Is the test runner client currently running tests
    /// </summary>
    bool IsRunning { get; }
    
    /// <summary>
    ///     Current test run
    /// </summary>
    TestJob? CurrentJob { get; }
    
    /// <summary>
    ///     Time when the runner started running the current test run
    /// </summary>
    DateTime JobStarted { get; }
    
    /// <summary>
    ///     Executes a test job on this test runner
    /// </summary>
    /// <param name="testJob"></param>
    /// <returns></returns>
    Task RunTestsAsync(TestJob? testJob);
}