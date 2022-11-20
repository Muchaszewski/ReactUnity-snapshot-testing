namespace ReactCompareOrchestrator.Features.TestRunnerStorage;

public record TestRunner(string Id, string Type, string Version) : ITestRunner
{
    /// <inheritdoc />
    public string Id { get; init; } = Id;
    
    /// <inheritdoc />
    public string Type { get; init; } = Type;

    /// <inheritdoc />
    public string Version { get; init; } = Version;
    
    /// <inheritdoc />
    public bool IsFree { get; set; } = true;
}