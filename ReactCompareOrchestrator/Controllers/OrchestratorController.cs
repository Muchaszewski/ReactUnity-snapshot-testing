using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using ReactCompareOrchestrator.Interfaces;

namespace ReactCompareOrchestrator.Controllers;

[Route("[controller]/[action]")]
public class OrchestratorController : Controller
{
    private readonly IOrchestratorService _service;

    public OrchestratorController(IOrchestratorService _service)
    {
        this._service = _service;
    }
    
    /// <summary>
    ///     Put a report result into the server memory for later retrieval and comparasion
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = long.MaxValue)]
    public ActionResult PutReportResult()
    {
        // Get the ReportResult and files from the request as multipart form data
        var connectionId = Request.Form["connectionId"].ToString();
        var runnerId = Request.Form["runnerId"].ToString();
        var appType = Enum.Parse<AppTypeEnum>(Request.Form["appType"].ToString());

        var runner = _service.GetApplication(connectionId).Clients.FirstOrDefault(client => client?.Id.ToString("N") == runnerId);
        
        if(runner == null)
            return BadRequest("Runner not found");
        _service.FreeTestRunner(runner);
        
        var files = Request.Form.Files;
        return Ok();
    }
}

public record ReportResult(string Id, string AppType, byte[] ResultImage);