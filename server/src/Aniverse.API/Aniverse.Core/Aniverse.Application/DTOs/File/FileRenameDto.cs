using Microsoft.AspNetCore.Http;

namespace Aniverse.Application.DTOs.File
{
    public class FileRenameDto
    {
        public string ContainerName { get; set; }
        public string Username { get; set; }
        public IFormFile File { get; set; }
    }
}
