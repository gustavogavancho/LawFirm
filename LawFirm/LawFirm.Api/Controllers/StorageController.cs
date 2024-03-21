using LawFirm.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("listFiles/{folder}")]
    public async Task<ActionResult<List<string>>> ListFiles(string folder)
    {
        var files = await _storageService.ListFiles(folder);

        return Ok(files);
    }

    [HttpPost("uploadFile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var url = await _storageService.UploadFile(stream, file.FileName);
            return Ok(new { Url = url });
        }

        return BadRequest("Invalid file");
    }

    [HttpGet("downloadFile")]
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DownloadFile([FromQuery] string fileName)
    {
        var stream = await _storageService.DownloadFile(fileName);

        if (stream == null) return NotFound();

        return File(stream, "application/octet-stream", fileName);
    }

    [HttpDelete("deleteFile")]
    public async Task<IActionResult> DeleteFile([FromQuery] string fileName)
    {
        var result = await _storageService.DeleteFile(fileName);
        
        if (result)
            return Ok(new { message = $"File {fileName} deleted successfully." });
        else 
            return NotFound(new { message = $"File {fileName} not found." });
    }
}