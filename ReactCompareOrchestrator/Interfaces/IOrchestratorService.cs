namespace ReactCompareOrchestrator.Interfaces;

/// <summary>
///     An orchestrator that will manage state of the application
/// </summary>
public interface IOrchestratorService
{
    /// <summary>
    ///     Register the application with the orchestrator
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    IApplicationContainer RegisterApplication(string connectionId);
    
    /// <summary>
    ///     Unregister the application with the orchestrator (eg. when the application is closed, or loses connection)
    /// </summary>
    /// <param name="connectionId"></param>
    void UnregisterApplication(string connectionId);
    
    /// <summary>
    ///     Unregister the application with the orchestrator (eg. when the application is closed, or loses connection)
    /// </summary>
    /// <param name="applicationContainer"></param>
    void UnregisterApplication(IApplicationContainer applicationContainer);
    
    /// <summary>
    ///     Get the application container for the given connection id
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    IApplicationContainer GetApplication(string connectionId);

    /// <summary>
    ///     List of all applications that are currently registered with the orchestrator
    /// </summary>
    /// <returns></returns>
    IEnumerator<IApplicationContainer> ListApplications();

    /// <summary>
    ///     Enqueue a test run request
    /// </summary>
    /// <param name="typeEnum">Type of the application to schedule the run for</param>
    /// <param name="testJob">Job parameters</param>
    void EnqueueTestJob(AppTypeEnum typeEnum, TestJob testJob);
    
    /// <summary>
    ///     Free up a test run client for new requests
    /// </summary>
    /// <param name="testRunner"></param>
    void FreeTestRunner(ITestRunnerClient testRunner);
}