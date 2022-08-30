using Aniverse.Application.Abstractions.Storage;
using Aniverse.Application.DTOs.File;
using Microsoft.AspNetCore.Http;

namespace Anivese.Infrastructure.Services.Storage;
public class StorageService : IStorageService
{
    readonly IStorage _storage;
    public StorageService(IStorage storage)
    {
        _storage = storage;
    }
    public string StorageName { get => _storage.GetType().Name; }

    public Task DeleteAsync(string containerName, string file) =>
        _storage.DeleteAsync(containerName, file);

    public List<string> GetFiles(string containerName) =>
        _storage.GetFiles(containerName);
    public bool HasFile(string containerName, string fileName) =>
        _storage.HasFile(containerName, fileName);

    public Task<List<FileUploadResponse>> UploadAsync(IFormFileCollection files, string containerName, string
         username = "") =>
        _storage.UploadAsync(files,containerName, username);
}
