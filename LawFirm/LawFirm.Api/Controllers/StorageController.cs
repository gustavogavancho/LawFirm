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

    [HttpGet("listfiles/{folder}")]
    public async Task<ActionResult<List<string>>> ListFiles(string folder)
    {
        var files = await _storageService.ListFilesAsync(folder);

        return Ok(files);
    }

    [HttpPost("uploadfile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                var url = await _storageService.UploadFileAsync(stream, file.FileName);

                return Ok(new { Url = url });
            }
        }

        return BadRequest("Invalid file");
    }

    [HttpGet("downloadfile/{fileName}")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        var stream = await _storageService.DownloadFileAsync(fileName);
        if (stream == null)
        {
            return NotFound();
        }

        return File(stream, "application/octet-stream", fileName);
    }

    [HttpDelete("deletefile/{fileName}")]
    public async Task<IActionResult> DeleteFile(string fileName)
    {
        var result = await _storageService.DeleteFileAsync(fileName);
        if (result)
        {
            return Ok(new { message = $"File {fileName} deleted successfully." });
        }
        else
        {
            return NotFound(new { message = $"File {fileName} not found." });
        }
    }
}