namespace ReactCompareOrchestrator.Features.TestRunnerStorage;

public static class TestRunnerStorageExtensions
{
    public static string GetLatestVersion(this ITestRunnerStorage storage, string testRunnerName)
    {
        return storage.GetVersions(testRunnerName).MaxBy(v => v) ?? throw new InvalidOperationException();
    }
}