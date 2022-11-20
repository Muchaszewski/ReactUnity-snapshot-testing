using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using ReactCompareOrchestrator;
using ReactCompareOrchestrator.Hub;
using ReactCompareOrchestrator.Interfaces;

public record PerformTestSettings(
    int Width, int Height, 
    int CaptureX, int CaptureY, int CaptureWidth, int CaptureHeight
    );


public class OrchestratorHub : Hub
{
    private readonly ILogger<OrchestratorHub> _logger;
    private readonly IOrchestratorService _service;

    public OrchestratorHub(ILogger<OrchestratorHub> logger, IOrchestratorService service)
    {
        _logger = logger;
        _service = service;
    }

    public override Task OnConnectedAsync()
    {
        _service.RegisterApplication(Context.ConnectionId);
        Clients.Caller.SendAsync("Connected", Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _service.UnregisterApplication(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }

    public record RegisterRunnerRequest(string AppType);
    public record RegisterRunnerResponse(string Id);
    public async Task<HubResponse<RegisterRunnerResponse>> RegisterRunner(RegisterRunnerRequest request)
    {
        // convert string AppType to enum
        if (!Enum.TryParse<AppTypeEnum>(request.AppType, true, out var appTypeEnum))
        {
            _logger.LogError("Invalid AppType: {AppType}", request.AppType);
            return new($"Invalid AppType: {appTypeEnum}");
        }
        if(appTypeEnum == AppTypeEnum.Unknown)
        {
            _logger.LogError("Unknown AppType: {AppType}", request.AppType);
            return new($"Unknown AppType: {appTypeEnum}");
        }
        var runnerClient = _service.GetApplication(Context.ConnectionId).RegisterClient(appTypeEnum);
        
        return new(new RegisterRunnerResponse(runnerClient.Id.ToString("N")));
    }
    
    public record UnregisterRunnerRequest(string Id);
    public record UnregisterRunnerResponse();

    public async Task<HubResponse<UnregisterRunnerResponse>> UnregisterRunner(UnregisterRunnerRequest request)
    {
        var app = _service.GetApplication(Context.ConnectionId);
        var runnerClient = app.Clients.FirstOrDefault(client => client.Id.ToString("N") == request.Id);
        if (runnerClient == null)
        {
            _logger.LogError("RunnerClient not found: {Id}", request.Id);
            return new($"RunnerClient not found: {request.Id}");
        }
        _service.GetApplication(Context.ConnectionId).UnregisterClient(runnerClient);
        
        return new(new UnregisterRunnerResponse());
    }
}