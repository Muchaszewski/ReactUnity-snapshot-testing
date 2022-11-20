using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace ReactCompareOrchestrator.Features.ImageCollection;

/// <summary>
///     Controller for the ImageCollection feature, which is responsible for gathering images from the test runners.
/// </summary>
public class ImageCollectionController : Controller
{
    private readonly ILogger<ImageCollectionController> _logger;
    private readonly IImageCollectionStorage _imageCollectionStorage;

    public ImageCollectionController(ILogger<ImageCollectionController> logger,
        IImageCollectionStorage imageCollectionStorage)
    {
        _logger = logger;
        _imageCollectionStorage = imageCollectionStorage;
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
        var json = Request.Form["json"].ToString();

        // Deserialize the ReportResult using the System.Text.Json serializer
        var reportResult = JsonSerializer.Deserialize<ImageTestResult>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        });

        if (reportResult == null)
            return BadRequest("No report result was provided");

        // Get the files from the request
        var files = Request.Form.Files;

        switch (files.Count)
        {
            case 0:
                _logger.LogWarning("No files were uploaded");
                return BadRequest("No files were uploaded");
            case > 1:
                _logger.LogWarning("More than one file was uploaded");
                return BadRequest("More than one file was uploaded");
            default:
            {
                // Save the ReportResult and the file to the storage
                var file = files.First();
                using var stream = file.OpenReadStream();
                _imageCollectionStorage.StoreReportResult(reportResult, stream);

                return Ok();
            }
        }
    }
}