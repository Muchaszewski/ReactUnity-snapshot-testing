using ReactCompareOrchestrator.Features.ImageCollection;

namespace ReactCompareOrchestrator.Features.TestRunner;

public interface ITestResult
{
    public List<IImageTestResult> Results { get; }
}

class TestResult : ITestResult
{
    public List<IImageTestResult> Results { get; } = new ();
}