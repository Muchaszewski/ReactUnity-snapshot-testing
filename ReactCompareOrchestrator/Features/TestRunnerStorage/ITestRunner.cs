namespace ReactCompareOrchestrator.Features.TestRunnerStorage;

/// <summary>
///     A test runner storage feature.
/// </summary>
public interface ITestRunner
{
    /// <summary>
    ///     Unique identifier for the test runner.
    /// </summary>
    public string Id { get; init; }
    
    /// <summary>
    ///     Type of the runner, this should be a predefined value by the server
    /// </summary>
    public string Type { get; init; }
    
    /// <summary>
    ///     Version of the runner, each type can have different version
    /// </summary>
    public string Version { get; init; }
    
    /// <summary>
    ///     Indicate weather the runner is free to perform a test
    /// </summary>
    public bool IsFree { get; set; }
}