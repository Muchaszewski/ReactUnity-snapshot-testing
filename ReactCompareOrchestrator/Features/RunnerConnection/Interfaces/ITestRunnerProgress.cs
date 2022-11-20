namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     Represents a request to progress on a test.
/// </summary>
public interface ITestRunnerProgress
{
    /// <summary>
    ///     Id of the test runner.
    /// </summary>
    public string TestRunnerId { get; }
    
    /// <summary>
    ///     Id of the test.
    /// </summary>
    public string TestId { get; }
    
    /// <summary>
    ///     Status of the test.
    /// </summary>
    public string TestStatus { get; }
    
    /// <summary>
    ///     Progress of the test. 0-100.
    /// </summary>
    public int Progress { get; }
}