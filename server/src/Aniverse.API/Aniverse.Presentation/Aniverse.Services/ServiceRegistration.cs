using Aniverse.Services.Abstractions.UnitOfWork;
using Aniverse.Services.Implementations.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Aniverse.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
        }
    }
}
