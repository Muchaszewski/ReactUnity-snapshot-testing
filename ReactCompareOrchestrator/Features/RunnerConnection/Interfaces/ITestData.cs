namespace ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

public interface ITestData
{
    /// <summary>
    ///     Raw HTML to be rendered.
    /// </summary>
    public string? Html { get; set; }
    
    /// <summary>
    ///     Raw CSS to be applied to the HTML. CSS cannot be part of the HTML.
    /// </summary>
    public string? Css { get; set; }
    
    /// <summary>
    ///     Raw JavaScript to be executed. JavaScript cannot be part of the HTML.
    /// </summary>
    public string? Js { get; set; } 
    
    /// <summary>
    ///     Raw react component to be rendered, this would be then compiled to ES5 and executed.
    /// </summary>
    public string? RawReactJs { get; set; }
    
    /// <summary>
    ///     Pre-compiled ES5 react component to be rendered. This is the fastest way to render react components.
    /// </summary>
    public string? CompiledReactJs { get; set; }
}