using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photo.Api.Services;

namespace Photo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IStorage _storage;

        public FilesController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file , CancellationToken cancellationToken) => Ok(await _storage.UploadFileAsync(file , cancellationToken));

        [HttpDelete]
        public async Task<IActionResult> DeleteFile(Dtos.File file) => Ok(await _storage.DeleteFileAsync(file));

    }
}
