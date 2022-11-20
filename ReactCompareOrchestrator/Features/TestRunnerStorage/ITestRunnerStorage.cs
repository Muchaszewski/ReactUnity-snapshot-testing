namespace ReactCompareOrchestrator.Features.TestRunnerStorage;

public interface ITestRunnerStorage
{
    /// <summary>
    ///   Adds a test run to the storage.
    /// </summary>
    public void AddTestRun(TestRunner testRun);
    
    /// <summary>
    ///     Returns the test run with the specified id.
    /// </summary>
    /// <param name="testRun"></param>
    public bool RemoveTestRun(TestRunner testRun);
    
    /// <summary>
    /// Gets all test runs.
    /// </summary>
    public IEnumerable<TestRunner> GetTestRunners(int page, int pageSize);
    
    /// <summary>
    ///  Gets the test run with the specified id.
    /// </summary>
    public TestRunner? GetTestRunner(string id);
    
    /// <summary>
    ///     Returns types of the test runners.
    /// </summary>
    /// <returns></returns>
    public string[] GetTypes();
    
    /// <summary>
    ///     Returns versions of the test runners, that are active.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public string[] GetVersions(string type);
    
    /// <summary>
    ///     Returns the test runner with the specified type and version that is ready to accept new test runs.
    /// </summary>
    /// <param name="type">Type</param>
    /// <param name="version">Version</param>
    /// <returns></returns>
    public TestRunner? GetFirstFreeTestRunner(string type, string version);
}