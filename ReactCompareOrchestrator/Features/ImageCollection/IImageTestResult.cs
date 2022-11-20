namespace ReactCompareOrchestrator.Features.ImageCollection;

/// <summary>
///     Result of the test
/// </summary>
public interface IImageTestResult
{
    /// <summary>
    ///     Path to the image
    /// </summary>
    public string? ImagePath { get; }
    
    /// <summary>
    ///     Id of the app that hold the runner
    /// </summary>
    public string ClientId { get; }
    
    /// <summary>
    ///     Id of the runner
    /// </summary>
    public string TestRunnerId { get; }
    
    /// <summary>
    ///     Type of the test runner
    /// </summary>
    public string TestRunnerType { get; }
    
    /// <summary>
    ///     Id of the test
    /// </summary>
    public string TestId { get; }
    
    /// <summary>
    ///     If the test failed, this is the reason
    /// </summary>
    public string? Exception { get; }
    
    /// <summary>
    ///     If the test failed, this is the stack trace
    /// </summary>
    public string? StackTrace { get; }
    
    /// <summary>
    ///     Additional data that can be used to filter the results
    /// </summary>
    public string? AdditionalInfo { get; }
}