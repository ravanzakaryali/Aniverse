using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aniverse.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AniverseDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Database")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AniverseDbContext>();
        }
    }
}
