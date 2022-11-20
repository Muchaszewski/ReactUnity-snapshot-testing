using System.Collections.Concurrent;
using ReactCompareOrchestrator.Features.ClientsStorage;
using ReactCompareOrchestrator.Features.TestRunnerStorage;

namespace ReactCompareOrchestrator.Features.ImageCollection;

/// <summary>
///     In memory storage for test results
/// </summary>
public class InMemoryImageCollectionStorage : IImageCollectionStorage
{
    private readonly ILogger<InMemoryImageCollectionStorage> _logger;
    private readonly IClientsStorage _clientStorage;
    private readonly ITestRunnerStorage _testRunnerStorage;

    private readonly ConcurrentDictionary<string, IImageTestResult?> _results = new();

    public InMemoryImageCollectionStorage(ILogger<InMemoryImageCollectionStorage> logger, IClientsStorage clientStorage, ITestRunnerStorage testRunnerStorage)
    {
        _logger = logger;
        _clientStorage = clientStorage;
        _testRunnerStorage = testRunnerStorage;
    }

    /// <inheritdoc />
    public void StoreReportResult(IImageTestResult rawResult, Stream imageStream)
    {
        //  Generate image path
        var client = _clientStorage.GetClient(rawResult.ClientId);
        var testRunner = _testRunnerStorage.GetTestRunner(rawResult.TestRunnerId);
        
        var imagePath = Path.Combine(testRunner.Type, testRunner.Version, rawResult.TestId);

        var testResult = ImageTestResult.FromSuccess(rawResult.ClientId, rawResult.TestRunnerId, rawResult.TestId, testRunner.Type, imagePath);
        // TODO handle failure
        
        // Save image to file
        var imageBytes = new byte[imageStream.Length];
        _ = imageStream.Read(imageBytes, 0, imageBytes.Length);
        File.WriteAllBytes(testResult.ImagePath!, imageBytes);
        
        _results.TryAdd(testResult.TestId, testResult);
    }

    /// <inheritdoc />
    public IImageTestResult? GetReportResult(string testId)
    {
        return _results.TryGetValue(testId, out var result) ? result : null;
    }

    /// <inheritdoc />
    public Stream GetImageStream(IImageTestResult testResult)
    {
        var imageBytes = File.ReadAllBytes(testResult.ImagePath!);
        return new MemoryStream(imageBytes);
    }

    /// <inheritdoc />
    public byte[] GetImageBytes(IImageTestResult testResult)
    {
        return File.ReadAllBytes(testResult.ImagePath!);
    }
}