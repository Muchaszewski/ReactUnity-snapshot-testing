namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     Register the test runner that can accept tests to run.
/// </summary>
public interface IRegisterTestRunnerRequest
{
    /// <summary>
    ///     Type of the runner, this should be a predefined value by the server
    /// </summary>
    public string TestRunnerType { get; init; }
    
    /// <summary>
    ///     Version of the runner, each type can have different version
    /// </summary>
    public string TestRunnerVersion { get; init; }
}