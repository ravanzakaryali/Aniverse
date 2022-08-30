using Aniverse.Application.DTOs.File;
using Microsoft.AspNetCore.Http;

namespace Aniverse.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<FileUploadResponse>> UploadAsync(IFormFileCollection files, string containerName="files", string username = "username");
        Task DeleteAsync(string containerName, string fileName);
        List<string> GetFiles(string containerName);
        bool HasFile(string containerName, string fileName);
    }
}
