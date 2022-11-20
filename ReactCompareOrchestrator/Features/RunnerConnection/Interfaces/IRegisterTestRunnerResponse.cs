namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     Response with the test runner id. This ID will be used to identify the test runner in the future.
/// </summary>
public interface IRegisterTestRunnerResponse
{
    public string TestRunnerId { get; }
}