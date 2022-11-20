namespace ReactCompareOrchestrator.Features.ImageCollection;

/// <summary>
///     Storage service for images from test results
/// </summary>
public interface IImageCollectionStorage
{
    /// <summary>
    ///     Put new image to storage from test result
    /// </summary>
    /// <param name="testResult">Meta data of the test</param>
    /// <param name="imageStream">Stream with an image</param>
    public void StoreReportResult(IImageTestResult testResult, Stream imageStream);
    
    /// <summary>
    ///     Get the report result from storage
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    public IImageTestResult? GetReportResult(string testId);
    
    /// <summary>
    ///     Get the image from storage
    /// </summary>
    /// <param name="testResult"></param>
    public Stream GetImageStream(IImageTestResult testResult);
    
    /// <summary>
    ///     Get the image from storage
    /// </summary>
    /// <param name="testResult"></param>
    /// <returns></returns>
    public byte[] GetImageBytes(IImageTestResult testResult);
}