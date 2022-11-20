namespace ReactCompareOrchestrator.Features.ImageCollection;

class ImageTestResult : IImageTestResult
{
    /// <summary>
    ///     Successful test result
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="testRunnerId"></param>
    /// <param name="testId"></param>
    /// <param name="runnerType"></param>
    /// <param name="imagePath"></param>
    /// <param name="additionalInfo"></param>
    /// <returns></returns>
    public static ImageTestResult FromSuccess(string appId, string testRunnerId, string testId, string runnerType, string imagePath, string? additionalInfo = null)
    {
        return new ImageTestResult()
        {
            ClientId = appId,
            TestRunnerId = testRunnerId,
            TestId = testId,
            TestRunnerType = runnerType,
            ImagePath = imagePath,
            AdditionalInfo = additionalInfo
        };
    }
    
    /// <summary>
    ///     Failed test result
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="testRunnerId"></param>
    /// <param name="testId"></param>
    /// <param name="exception"></param>
    /// <param name="additionalInfo"></param>
    /// <returns></returns>
    public static ImageTestResult FromException(string appId, string testRunnerId, string testId, string runnerType, Exception exception, string? additionalInfo = null)
    {
        return new ImageTestResult()
        {
            ClientId = appId,
            TestRunnerId = testRunnerId,
            TestId = testId,
            TestRunnerType = runnerType,
            Exception = exception.Message,
            StackTrace = exception.StackTrace,
            AdditionalInfo = additionalInfo
        };
    }
    
    /// <summary>
    ///     Failed test result with an image
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="testRunnerId"></param>
    /// <param name="testId"></param>
    /// <param name="exception"></param>
    /// <param name="imagePath"></param>
    /// <param name="additionalInfo"></param>
    /// <returns></returns>
    public static ImageTestResult FromExceptionWithImage(string appId, string testRunnerId, string testId, string runnerType, Exception exception, string imagePath, string? additionalInfo = null)
    {
        return new ImageTestResult()
        {
            ClientId = appId,
            TestRunnerId = testRunnerId,
            TestId = testId,
            TestRunnerType = runnerType,
            Exception = exception.Message,
            StackTrace = exception.StackTrace,
            ImagePath = imagePath,
            AdditionalInfo = additionalInfo
        };
    }
    
    /// <inheritdoc />
    public string? ImagePath { get; init; }
    /// <inheritdoc />
    public string ClientId { get; init; }
    /// <inheritdoc />
    public string TestRunnerId { get; init; }
    /// <inheritdoc />
    public string TestRunnerType { get; init; }
    /// <inheritdoc />
    public string TestId { get; init; }
    /// <inheritdoc />
    public string? Exception { get; init; }
    /// <inheritdoc />
    public string? StackTrace { get; init; }
    /// <inheritdoc />
    public string? AdditionalInfo { get; init; }
}