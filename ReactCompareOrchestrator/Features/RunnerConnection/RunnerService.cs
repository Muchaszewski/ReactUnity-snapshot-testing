using Microsoft.AspNetCore.SignalR;
using ReactCompareOrchestrator.Features.ClientsStorage;
using ReactCompareOrchestrator.Features.RunnerConnection.Hub;
using ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

namespace ReactCompareOrchestrator.Features.RunnerConnection;

public class RunnerService
{
    private readonly ILogger<RunnerService> _logger;
    private readonly InMemoryClientStorage _clientStorage;

    public RunnerService(ILogger<RunnerService> logger, InMemoryClientStorage clientStorage)
    {
        _logger = logger;
        _clientStorage = clientStorage;
    }
    
    public async Task OnConnectedAsync(HubCallerContext context)
    {
        _logger.LogInformation("Runner connected: {ConnectionId}", context.ConnectionId);
    }

    public async Task OnDisconnectedAsync(HubCallerContext context, Exception? exception)
    {
        _logger.LogInformation("Runner disconnected: {ConnectionId}", context.ConnectionId);
    }

    public async Task<IRegisterClientResponse> RegisterClientAsync(HubCallerContext context, IRegisterClientRequest request)
    {
        _logger.LogInformation("Runner registered: {ConnectionId}", context.ConnectionId);
        var clientType = new ClientType(context.ConnectionId, request.AppType, request.AppVersion);
        _clientStorage.AddClient(clientType);
        return new RegisterClientResponse();
    }

    public async Task<IRegisterTestRunnerResponse> RegisterTestRunnerAsync(HubCallerContext context, IRegisterTestRunnerRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task TestRunnerProgress(HubCallerContext context, ITestRunnerProgress progress)
    {
        throw new NotImplementedException();
    }
}