namespace ReactCompareOrchestrator;

/// <summary>
///     A job that can be queued.
/// </summary>
/// <param name="Html">Html data that should the runner take</param>
/// <param name="Style">CSS Style that should the runner take</param>
/// <param name="Settings">Additional settings</param>
public record TestJob(string Html, string Style, TestJobSettings? Settings = default);