using LawFirm.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var files = await _storageService.ListFilesAsync();

            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    var url = await _storageService.UploadFileAsync(stream, fileName);
                    return Ok(new { Url = url });
                }
            }

            return BadRequest("Invalid file");
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            var stream = await _storageService.DownloadFileAsync(fileName);
            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "application/octet-stream", fileName);
        }

        [HttpDelete("delete/{fileName}")]
        public async Task<IActionResult> Delete(string fileName)
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
}
