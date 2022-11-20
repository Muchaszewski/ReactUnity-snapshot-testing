namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

public record RunTestRequest : IRunTestRequest
{
    /// <inheritdoc />
    public string AppClientId { get; set; }

    /// <inheritdoc />
    public string TestRunnerId { get; set; }

    /// <inheritdoc />
    public string TestId { get; set; }

    /// <inheritdoc />
    public ITestData TestData { get; set; }
}