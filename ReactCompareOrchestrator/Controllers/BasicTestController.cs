using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ReactCompareOrchestrator.Interfaces;

namespace ReactCompareOrchestrator.Controllers;

[Route("[controller]/[action]")]
public class BasicTestController : Controller
{
    private readonly IOrchestratorService _service;

    public BasicTestController(IOrchestratorService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public ActionResult<string> PerformTest()
    {
        //Request.Body.Position = 0;
        using var reader = new MemoryStream();
        Request.Body.CopyToAsync(reader).Wait();
        reader.Position = 0;
        var rawRequestBody = new StreamReader(reader).ReadToEnd();
        // Read body as XML, and separate <body> content and <style> content
        var xml = XDocument.Parse(rawRequestBody);
        var body = xml.Root?.Element("body")?.Value;
        var style = xml.Root?.Element("style")?.Value;
        
        var testJob = new TestJob(body, style, TestJobSettings.Default);

        // Call Orchestrator service for each of the appTypeEnum
        var tests = Enum.GetValues<AppTypeEnum>()[1..];
        foreach (var appTypeEnum in tests)
        {
            _service.EnqueueTestJob(appTypeEnum, testJob);
        }
        return Ok();
    }
}