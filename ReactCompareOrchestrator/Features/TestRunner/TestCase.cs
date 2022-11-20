using ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

namespace ReactCompareOrchestrator.Features.TestRunner;

public class TestCase : ITestCase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string[]? Category { get; set; }
    public string[]? Tags { get; set; }
    public string[]? RunnersTypes { get; set; }
    public ITestData TestData { get; set; }
}