using Microsoft.AspNetCore.SignalR;
using ReactCompareOrchestrator.Features.RunnerConnection.Interfaces;

namespace ReactCompareOrchestrator.Features.RunnerConnection.Hub;

/// <summary>
///     Hub for runner connection, handled by RunnerService
/// </summary>
public class RunnerHub : Hub<IRunnerConnectionHub>, IRunnerConnectionHub
{
    private readonly RunnerService _runnerService;

    public RunnerHub(RunnerService runnerService)
    {
        _runnerService = runnerService;
    }

    /// <inheritdoc cref="IRunnerConnectionHub.OnConnectedAsync" />
    public override async Task OnConnectedAsync()
    {
        await _runnerService.OnConnectedAsync(Context);
    }

    /// <inheritdoc cref="IRunnerConnectionHub.OnDisconnectedAsync"/>
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _runnerService.OnDisconnectedAsync(Context, exception);
    }

    /// <inheritdoc />
    public async Task<IRegisterClientResponse> RegisterClientAsync(IRegisterClientRequest request)
    {
        return await _runnerService.RegisterClientAsync(Context, request);
    }

    /// <inheritdoc />
    public async Task<IRegisterTestRunnerResponse> RegisterTestRunnerAsync(IRegisterTestRunnerRequest request)
    {
        return await _runnerService.RegisterTestRunnerAsync(Context, request);
    }

    /// <inheritdoc />
    public async Task TestRunnerProgress(ITestRunnerProgress progress)
    {
        await _runnerService.TestRunnerProgress(Context, progress);
    }
}