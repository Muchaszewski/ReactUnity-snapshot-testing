using ReactCompareOrchestrator.Interfaces;

namespace ReactCompareOrchestrator.Services;

/// <summary>
///     A test runner client that can be used to run tests
/// </summary>
public class TestRunnerClient : ITestRunnerClient
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="parent">Parent application container</param>
    /// <param name="appType">Application type of the runner</param>
    public TestRunnerClient(IApplicationContainer parent, AppTypeEnum appType)
    {
        Parent = parent;
        Id = Guid.NewGuid();
        AppType = appType;
    }

    /// <summary>
    ///     Parent application container
    /// </summary>
    public IApplicationContainer Parent { get; }

    /// <summary>
    ///     Unique identifier of the test runner client
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Type of the test runner client
    /// </summary>
    public AppTypeEnum AppType { get; }

    /// <summary>
    ///     Is the test runner client currently running tests
    /// </summary>
    public bool IsRunning => CurrentJob != null;

    /// <summary>
    ///     Current test run
    /// </summary>
    public TestJob? CurrentJob { get; private set; }

    /// <summary>
    ///     Time when the runner started running the current test run
    /// </summary>
    public DateTime JobStarted { get; private set; }

    /// <summary>
    ///     Executes a test job on this test runner
    /// </summary>
    /// <param name="testJob"></param>
    /// <returns></returns>
    public async Task RunTestsAsync(TestJob? testJob)
    {
        // Set the current job
        CurrentJob = testJob;

        // Set the job started time
        JobStarted = DateTime.UtcNow;
        
        throw new NotImplementedException();
    }
}