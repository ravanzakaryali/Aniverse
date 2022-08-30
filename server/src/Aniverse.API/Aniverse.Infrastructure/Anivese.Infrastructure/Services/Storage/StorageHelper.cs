using Aniverse.Application.Statics;
namespace Anivese.Infrastructure.Services.Storage;
public class StorageHelper
{
    public string FileRename(string fileName, string username, string containerName, Func<string, string, bool> hasfileMethod)
    {
        string newFileName = NewFileName(fileName, username);
        if (hasfileMethod(containerName, fileName))
            return FileRename(fileName, username, containerName, hasfileMethod);
        else
            return newFileName;
    }
    public string NewFileName(string fileName, string username)
    {
        string extension = Path.GetExtension(fileName);
        return StringHelper.WithDate(String.Concat(username, Path.GetFileNameWithoutExtension(fileName)), extension);
    }
}
