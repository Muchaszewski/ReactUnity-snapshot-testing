namespace ReactCompareOrchestrator.Hub;

public struct HubResponse<T>
{
    public T Data { get; set; }
    public string Error { get; set; }
    
    public HubResponse(T data)
    {
        Data = data;
        Error = null;
    }
    
    public HubResponse(string error)
    {
        Data = default(T);
        Error = error;
    }
}