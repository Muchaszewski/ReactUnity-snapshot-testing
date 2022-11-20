namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     List of requests that can be sent to the server.
/// </summary>
public interface IRunnerConnectionRequests
{
    public Task RunTestAsync(IRunTestRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="runnerType"></param>
    /// <param name="runnerVersion"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> GetFreeRunnerAsync(string runnerType, string runnerVersion, CancellationToken cancellationToken);
}