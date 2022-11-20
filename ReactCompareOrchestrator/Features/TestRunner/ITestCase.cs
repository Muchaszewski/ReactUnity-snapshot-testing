using ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

namespace ReactCompareOrchestrator.Features.TestRunner;

/// <summary>
///     Description of the test case.
/// </summary>
public interface ITestCase
{
    /// <summary>
    ///     Test case name
    /// </summary>
    string Name { get; set; }
    
    /// <summary>
    ///     Test case description
    /// </summary>
    string? Description { get; set; }
    
    /// <summary>
    ///     Test case categories
    /// </summary>
    string[]? Category { get; set; }
    
    /// <summary>
    ///     Test case tags
    /// </summary>
    string[]? Tags { get; set; }
    
    /// <summary>
    ///     Limit the runners type to a specific type
    /// </summary>
    string[]? RunnersTypes { get; set; }
    
    /// <summary>
    ///     Test data
    /// </summary>
    ITestData TestData { get; set; }
}