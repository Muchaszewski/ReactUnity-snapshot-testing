namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

/// <summary>
///     The test data to be sent to the runner and executed.
/// </summary>
class TestData : ITestData
{
    public string? Html { get; set; }
    public string? Css { get; set; }
    public string? Js { get; set; }
    public string? RawReactJs { get; set; }
    public string? CompiledReactJs { get; set; }
}