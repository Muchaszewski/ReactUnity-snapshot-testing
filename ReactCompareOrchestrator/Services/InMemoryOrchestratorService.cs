using System.Collections.Concurrent;
using ReactCompareOrchestrator.Interfaces;

namespace ReactCompareOrchestrator.Services;

public class InMemoryOrchestratorService : IOrchestratorService
{
    /// <summary>
    ///     A lock object to ensure that only one thread can access the object at a time.
    /// </summary>
    private readonly object _lock = new();

    private readonly Dictionary<string, IApplicationContainer> _containers = new();
    
    /// <summary>
    ///     List of scheduled jobs to be executed.
    /// </summary>
    private readonly Dictionary<AppTypeEnum, ConcurrentQueue<TestJob>> _queue = new();

    /// <summary>
    ///     Register the application with the orchestrator
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    public IApplicationContainer RegisterApplication(string connectionId)
    {
        lock (_lock)
        {
            var container = new ApplicationContainer(connectionId);
            _containers.Add(connectionId, container);
            return container;
        }
    }

    /// <summary>
    ///     Unregister the application with the orchestrator (eg. when the application is closed, or loses connection)
    /// </summary>
    public void UnregisterApplication(string connectionId)
    {
        lock (_lock)
        {
            _containers.Remove(connectionId);
        }
    }

    /// <summary>
    ///     Unregister the application with the orchestrator (eg. when the application is closed, or loses connection)
    /// </summary>
    /// <param name="applicationContainer"></param>
    public void UnregisterApplication(IApplicationContainer applicationContainer)
    {
        lock (_lock)
        {
            _containers.Remove(applicationContainer.ConnectionId);
        }
    }

    /// <summary>
    ///     Get the application container for the given connection id
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IApplicationContainer GetApplication(string connectionId)
    {
        lock (_lock)
        {
            return _containers[connectionId];
        }
    }

    /// <summary>
    ///     List of all applications that are currently registered with the orchestrator
    /// </summary>
    /// <returns></returns>
    public IEnumerator<IApplicationContainer> ListApplications()
    {
        lock (_lock)
        {
            return _containers.Values.GetEnumerator();
        }
    }

    /// <summary>
    ///     Schedule a test job to be executed by a test runner
    /// </summary>
    /// <param name="typeEnum"></param>
    /// <param name="testJob"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void EnqueueTestJob(AppTypeEnum typeEnum, TestJob testJob)
    {
        _queue[typeEnum].Enqueue(testJob);
    }


    /// <summary>
    ///     Free up a test run client for new requests
    /// </summary>
    /// <param name="testRunner"></param>
    public void FreeTestRunner(ITestRunnerClient testRunner)
    {
        
    }
}