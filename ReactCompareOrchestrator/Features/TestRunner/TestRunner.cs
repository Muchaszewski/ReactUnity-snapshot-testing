using ReactCompareOrchestrator.Features.ImageCollection;
using ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;
using ReactCompareOrchestrator.Features.TestRunnerStorage;

namespace ReactCompareOrchestrator.Features.TestRunner;


public interface ITestRunner
{
    public Task<ITestResult> RunTestAsync(ITestCase testCase, CancellationToken cancellationToken);
    
    public Task<string[]> RunTestsAsync(ITestCase[] testCases, CancellationToken cancellationToken);
}

public class TestRunner : ITestRunner
{
    private readonly ILogger<TestRunner> _logger;
    private readonly IImageCollectionStorage _imageCollectionStorage;
    private readonly IRunnerConnectionRequests _runnerConnectionRequests;
    private readonly ITestRunnerStorage _runnerStorage;

    public TestRunner(ILogger<TestRunner> logger, IImageCollectionStorage imageCollectionStorage, IRunnerConnectionRequests runnerConnectionRequests, ITestRunnerStorage runnerStorage)
    {
        _logger = logger;
        _imageCollectionStorage = imageCollectionStorage;
        _runnerConnectionRequests = runnerConnectionRequests;
        _runnerStorage = runnerStorage;
    }

    public async Task<ITestResult> RunTestAsync(ITestCase testCase, CancellationToken cancellationToken)
    {
        // Get all runners types and get the latest version of each.
        var runnersTypes = _runnerStorage.GetTypes();
        (string Type, string Version)[] runners = runnersTypes.Select(x => (x, _runnerStorage.GetLatestVersion(x))).ToArray();
        
        // Get runners that are free to run the test for each runner type.
        // var runnersToRun = await GetRunnersToRunAsync(runners, cancellationToken);
        
        
        IRunTestRequest testRequest = new RunTestRequest()
        {
            TestId = Guid.NewGuid().ToString("N"),
            TestData = testCase.TestData
        };

        throw new NotImplementedException();
    }


    public async Task<string[]> RunTestsAsync(ITestCase[] testCases, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}