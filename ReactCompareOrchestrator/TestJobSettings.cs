namespace ReactCompareOrchestrator;

/// <summary>
///     Additional settings for a job.
/// </summary>
/// <param name="AppTypes"></param>
/// <param name="Timeout"></param>
public record TestJobSettings(AppTypeEnum AppTypes, TimeSpan Timeout)
{
    public static TestJobSettings Default => new(
        AppTypeEnum.Native | AppTypeEnum.UGuiReact | AppTypeEnum.UiElementsReact, 
        TimeSpan.FromSeconds(30));
}