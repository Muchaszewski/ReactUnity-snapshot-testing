using System.Collections.Concurrent;

namespace ReactCompareOrchestrator.Features.TestRunnerStorage;

public class InMemoryTestRunnerStorage : ITestRunnerStorage
{
    private readonly ConcurrentDictionary<string, TestRunner> _testRuns = new();
    
    public void AddTestRun(TestRunner testRun)
    {
        _testRuns.AddOrUpdate(testRun.Id, testRun, (_, _) => testRun);
    }
    
    public bool RemoveTestRun(TestRunner testRun)
    {
        return _testRuns.TryRemove(testRun.Id, out _);
    }

    public string[] GetTypes()
    {
        return _testRuns.Values.Select(x => x.Type).Distinct().ToArray();
    }

    public string[] GetVersions(string type)
    {
        return _testRuns.Values.Where(x => x.Type == type).Select(x => x.Version).Distinct().ToArray();
    }

    public TestRunner? GetFirstFreeTestRunner(string type, string version)
    {
        return _testRuns.Values.FirstOrDefault(x => x.Type == type && x.Version == version && x.IsFree);
    }

    public IEnumerable<TestRunner> GetTestRunners(int page, int pageSize)
    {
        return _testRuns.Values.Skip(page * pageSize).Take(pageSize);
    }
    
    public TestRunner? GetTestRunner(string id)
    {
        return _testRuns.TryGetValue(id, out var testRun) ? testRun : null;
    }
}