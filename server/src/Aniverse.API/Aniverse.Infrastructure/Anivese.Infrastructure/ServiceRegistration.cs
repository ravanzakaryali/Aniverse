using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.Abstractions.Storage;
using Anivese.Infrastructure.Services.Storage;
using Anivese.Infrastructure.Services.Storage.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Anivese.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorage, AzureStorage>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddStorage<AzureStorage>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : StorageHelper, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
