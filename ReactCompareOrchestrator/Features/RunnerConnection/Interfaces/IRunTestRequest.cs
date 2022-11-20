namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     Represents a single test run.
/// </summary>
public interface IRunTestRequest
{
    /// <summary>
    ///     Id of the application to run the test against. This should be the same as ConnectionId of SignalR connection.
    /// </summary>
    public string AppClientId { get; set; }

    /// <summary>
    ///     Id of the test runner to run the test against. This should be some unique identifier.
    /// </summary>
    public string TestRunnerId { get; set; }

    /// <summary>
    ///     Id of the test to run. This should be some unique identifier.
    /// </summary>
    public string TestId { get; set; }

    /// <summary>
    ///     Data of the test to run.
    /// </summary>
    public ITestData TestData { get; set; }
}