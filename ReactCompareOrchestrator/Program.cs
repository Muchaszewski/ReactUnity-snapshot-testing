using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ReactCompareOrchestrator;
using ReactCompareOrchestrator.Interfaces;
using ReactCompareOrchestrator.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", b =>
    {
        b.SetIsOriginAllowed(s => true);
    });
});

services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = long.MaxValue; // if don't set default value is: 30 MB
});

// Add services to the container.
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddSingleton<IOrchestratorService, InMemoryOrchestratorService>();
services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Use((context, func) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    return func();
});

app.MapHub<OrchestratorHub>("/orchestrator");

app.Run();