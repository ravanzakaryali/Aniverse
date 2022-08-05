using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Aniverse.Application.Mappers
{
    public static class MapperExtensions
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddScoped(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            }).CreateMapper());
        }
    }
}
