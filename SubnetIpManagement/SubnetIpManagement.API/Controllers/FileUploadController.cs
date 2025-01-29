using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubnetIpManagement.API.Services;

namespace SubnetIpManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController(FileService fileService) : ControllerBase
    {
        private readonly FileService _fileService = fileService;

        [HttpPost("upload-subnet")]
        public async Task<IActionResult> UploadSubnetFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file was uploaded or file is empty.");

            try
            {
                await _fileService.ProcessSubnetFileAsync(file);
                return Ok("File processed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
